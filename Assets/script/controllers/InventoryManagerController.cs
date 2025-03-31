using System.Collections.Generic;
using UnityEngine;

public class InventoryManagerController : MonoBehaviour
{
    #region Properties
    [SerializeField]
    GameObject _playerGo;
    [SerializeField]
    GameObject _directionLaunchGo;    
    [SerializeField]
    GameObject _placeToDrop;
    [SerializeField]
    List<GameObject> _itemListGo;
    [SerializeField]
    GenericBagScriptable _currentBag;
    [SerializeField]
    protected List<KeyCode> _keyCodesShortCutList;
    public static InventoryManagerController Instance; 
    #endregion
    #region Methods
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        InventoryView.Instance.Initiate(_currentBag);

        BagScriptable resultBag = CastGenericBagToBag();
        ShortCutView.Instance.InitiateShortCutSlots(resultBag.MaxShortCutSlots);
    }
    void Update()
    {
        UseShortCut();

        if (Input.GetKeyDown(KeyCode.R))
        {
            BuildMeshModel(Random.Range(1, 21), 1);
        }

        if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape))
        {
            ShowAndHide();
        }
    }
    void UseShortCut()
    {
        for(int i = 0; i < _keyCodesShortCutList.Count; i++)
        {
            if (Input.GetKeyDown(_keyCodesShortCutList[i]))
            {
                
            }
        }
    }
    void UseItem(int id, int number)
    {
        bool result = _currentBag.UseItem(id, number);

        if (result)
        {
            GenericItemScriptable item = _currentBag.FindItemById(id);
            //Refresh
        }
    }
    public bool AddItemToCurrentBag(GenericItemScriptable item, int number, bool exceptionCase)
    {
        bool result = _currentBag.AddItem(item, number);

        if (true)
        {
            if (result)
            {
                List<GenericItemScriptable> resultItemList = _currentBag.ReturnFullList();
                InventoryView.Instance.UpdateAllItems(resultItemList);
            }

            if (_currentBag.UsedOrganizeBySizePriority)
            {
                List<GenericItemScriptable> resultItemList = _currentBag.ReturnFullList();
                InventoryView.Instance.UpdateAllItems(resultItemList);
                _currentBag.UsedOrganizeBySizePriority = false;
            }

            //Refresh Shortcuts
        }

        return result;
    }
    public void OrganizeItem()
    {

    }
    public bool RemoveItem()
    {
        return true;
    }
    public bool DropItem(GenericItemScriptable item)
    {
        bool result = false;
        int currentNumber;

        if(item.Id >= 0)
        {
            currentNumber = item.CurrentNumber;
            result = _currentBag.DropItem(item.Id);

            if (result)
            {
                //Update View
                BuildMeshModel(item.Id, currentNumber);
            }
        }
        
        return result;
    }
    void BuildMeshModel(int id, int currentNumber)
    {
        GameObject result = _itemListGo?.Find(x => x.GetComponent<ItemView>() != null && x.GetComponent<ItemView>().Item.Id == id);

        if (result == null)
            return;

        Vector3 placeLaunchPos = _directionLaunchGo.transform.position;
        Vector3 directionPos = _directionLaunchGo.transform.forward;
        Quaternion playerRotation = _playerGo.transform.rotation;
        Vector3 spawnPpos = placeLaunchPos + directionPos;
        GameObject newInstance = Instantiate(result, spawnPpos, playerRotation);
        newInstance.name = $"{newInstance.GetComponent<ItemView>().Item.name}_{Time.realtimeSinceStartup}";
        newInstance.GetComponent<ItemView>().Number = currentNumber;
        newInstance.transform.SetParent(_placeToDrop.transform, true);

        float yForce = Random.Range(50, 250);
        float zForce = Random.Range(75, 300);
        newInstance.GetComponentInChildren<Rigidbody>().AddRelativeForce(new Vector3(0, yForce, zForce));
    }
    void ShowAndHide()
    {
        //Updates
        InventoryView.Instance.ShowAndHide();
    }
    #endregion
    #region OnDropItem and OnPointDown Methods
    public bool OnDropItem(GenericItemScriptable itemDrop, GameObject origin, Vector2 coordinate, SlotPlaceTo slotPlaceTo)
    {

        return false;
    }
    public void OnPointerDownItem(GenericItemScriptable itemPointer, GameObject origin)
    {
        if(origin.transform.parent.parent.name == "InventoryPanel")
        {
            InventoryView.Instance.UpdateDescriptionAndDetailPanel(itemPointer);
        }
    }
    #endregion
    #region Helpers Methods
    BagScriptable CastGenericBagToBag() =>
        (_currentBag is BagScriptable bag) ? bag : ScriptableObject.CreateInstance<BagScriptable>();
    #endregion
}
