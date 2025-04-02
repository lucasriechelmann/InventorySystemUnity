using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class ShortCutView : MonoBehaviour
{
    #region Properties
    [SerializeField]
    GameObject _shortCutGo;
    [SerializeField]
    GameObject _slotSpecialGroup;
    [SerializeField]
    GameObject _specialSlotGo;
    Dictionary<int, GameObject> _specialSlotDictionary;
    public static ShortCutView Instance { get; private set; }
    #endregion
    #region Methods
    void Awake()
    {
        Instance = GetComponent<ShortCutView>();
    }
    public void InitiateShortCutSlots(int maxShortCutSlots)
    {
        for(int column = 0; column < maxShortCutSlots; column++)
        {
            GameObject resultGo = Instantiate(_specialSlotGo);
            SimpleSlotView[] resultSimpleSlotViewList = resultGo.GetComponentsInChildren<SimpleSlotView>();

            if (!(resultSimpleSlotViewList[0].Equals(null)))
            {
                resultSimpleSlotViewList[0].Coordinate = new Vector2(0, column);
                resultSimpleSlotViewList[0].SlotPlaceTo = SlotPlaceTo.SHORT_CUT;
            }

            resultGo.transform.SetParent(_slotSpecialGroup.transform);
        }

        _specialSlotDictionary = new();
        GameObject[] resultList = GameObject.FindGameObjectsWithTag("SpecialSlot");
        int index = 0;

        foreach(var specialSlotGo in resultList)
        {
            _specialSlotDictionary.Add(index, specialSlotGo);
            index++;
        }
    }
    public void UpdateSlot(Dictionary<int, GenericItemScriptable> itemShortCutDictionary, List<int> usedKeys)
    {
        foreach(var key in usedKeys)
        {
            KeyValuePair<int, GameObject> resultSpecialSlotDictionary = _specialSlotDictionary.First(element => element.Key == key);
            resultSpecialSlotDictionary.Value.GetComponent<DisplayItemBehaviourView>().TurnOn();

            KeyValuePair<int, GenericItemScriptable> resultItemShortCutDictionary = itemShortCutDictionary.First(element => element.Key == key);
            GenericItemScriptable resultItem = resultItemShortCutDictionary.Value;

            ComplexSlotView complexSlotView = resultSpecialSlotDictionary.Value.GetComponentInChildren<ComplexSlotView>();
            complexSlotView.ItemView = resultItem;
            complexSlotView.UpdateText();
            complexSlotView.UpdateIcon();
        }
    }
    #endregion
}
