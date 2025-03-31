using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using System.Collections.Generic;
public class InventoryView : MonoBehaviour
{
    #region Properties
    GenericBagScriptable _currentBag;
    bool _visiblePanel;
    string _s = "/";
    string _w = "Kg";
    string _n = "Slot";
    float cellSize = 50;
    [SerializeField]
    GameObject _inventoryGO;
    [SerializeField]
    GameObject _clothingWeaponGo;
    [SerializeField]
    GameObject _slotGroup;
    [SerializeField]
    GameObject _slotGO;
    [SerializeField]
    GameObject _complexSlotGroup;
    [SerializeField]
    GameObject _complexSlotGo;
    #endregion
    #region Title Panel
    [SerializeField]
    Image _bagIcon;
    [SerializeField]
    TextMeshProUGUI _bagTitle;
    [SerializeField]
    TextMeshProUGUI _bagWeight;
    [SerializeField]
    TextMeshProUGUI _bagSlot;
    [SerializeField]
    Image _itemIconTitlePanel;
    [SerializeField]
    TextMeshProUGUI _itemCurrentNumber;
    [SerializeField]
    TextMeshProUGUI _itemMaxNumber;
    [SerializeField]
    TextMeshProUGUI _itemCurrentWeight;
    [SerializeField]
    TextMeshProUGUI _itemMaxWeight;
    #endregion
    #region Description Panel
    [SerializeField]
    TextMeshProUGUI _itemText;
    [SerializeField]
    TextMeshProUGUI _typeText;
    [SerializeField]
    TextMeshProUGUI _descriptionText;
    #endregion
    #region Detail Panel
    [SerializeField]
    Image _itemIconDetailPanel;
    [SerializeField]
    TextMeshProUGUI _currentNumberText;
    [SerializeField]
    TextMeshProUGUI _maxNumberText;
    [SerializeField]
    TextMeshProUGUI _totalWeightPerItemNumberText;
    #endregion
    #region Designer and Slot Control
    [SerializeField]
    List<GameObject> _simpleSlotList;
    [SerializeField]
    GridLayoutGroup _gridController;
    public static InventoryView Instance{ get; private set; }
    #endregion
    #region Getter and Setters
    public bool VisiblePanel => _visiblePanel;
    #endregion
    #region Methods
    void OnEnable()
    {
        _visiblePanel = _inventoryGO.activeSelf;
    }
    void Awake()
    {
        Instance = this;
    }
    public void Initiate(GenericBagScriptable currentBag)
    {
        _currentBag = currentBag;
        SlotAndGridUpdate(_currentBag.MaxRows, _currentBag.MaxColumns);
        BagIconAndTitleUpdate();
        BagWeightAndSlotUpdate();
    }
    void SlotAndGridUpdate(int maxRow, int maxColumn)
    {
        int r = 0;
        int c = 0;

        if(maxColumn <= 9)
        {
            int adjust = 500 - (maxColumn * 50);
            _gridController.padding.right = adjust;
        }

        for(int i = 0; i < maxRow * maxColumn; i++)
        {
            GameObject currentSlotGo = Instantiate(_slotGO);
            currentSlotGo.GetComponent<SimpleSlotView>().Coordinate = new(r, c);
            currentSlotGo.tag = "SlotSimple";
            c++;

            if (c == maxColumn)
            {
                c = 0;
                r++;
            }
            currentSlotGo.transform.SetParent(_slotGroup.gameObject.transform);
        }
    }
    
    void BagIconAndTitleUpdate()
    {
        _bagIcon.sprite = _currentBag.Icon;
        _bagTitle.text = _currentBag.Title;
    }
    void BagWeightAndSlotUpdate()
    {
        float maxWeight = _currentBag.WeightLimit;
        int maxSlot = _currentBag.SlotLimited;        
        _bagWeight.text = _currentBag.CurrentWeight.ToString() + _s + maxWeight.ToString() + _w;
        _bagSlot.text = _currentBag.CurrentSlot.ToString() + _s + maxSlot.ToString() + _n;
    }
    public void UpdateAllItems(List<GenericItemScriptable> list)
    {
        //Check Inventory Panel
        if (true)
        {
            foreach (GenericItemScriptable item in list)
                BuildComplexSlot(item);

            BagWeightAndSlotUpdate();
        }
    }
    void BuildComplexSlot(GenericItemScriptable item)
    {
        Vector3 pos = new(0, 0, 0);
        Vector2 size = new(cellSize, cellSize);
        Vector2 factor = new(1, 1);
        List<Vector2> cellList = _currentBag.FindCellById(item.Id);

        if (cellList.Count > 1)
        {
            factor = cellList[cellList.Count - 1] - cellList[0];
            size = new Vector2((cellSize * factor.y) + cellSize, (cellSize * factor.x) + cellSize);

            if (size.x == 0)
            {
                size = new Vector2(cellSize, size.y);
            }

            if (size.y == 0)
            {
                size = new Vector2(size.x, cellSize);
            }
        }

        pos = new Vector3(cellSize * cellList[0].y, (cellSize * cellList[0].x * -1));

        GameObject obj = Instantiate(_complexSlotGo);

        obj.transform.SetParent(_complexSlotGroup.transform);
        RectTransform rectTransform = obj.GetComponent<RectTransform>();
        rectTransform.localPosition = pos;
        rectTransform.sizeDelta = size;
        ComplexSlotView complexSlotView = obj.GetComponent<ComplexSlotView>();
        complexSlotView.ItemView = item;
        complexSlotView.UpdateIcon();
        complexSlotView.UpdateText();
        obj.tag = "ComplexSlot";
        obj.name = item.name + "_Clone";
    }
    void RemoveAllComplexSlot()
    {
        GameObject[] resultComplexSlotGo = GameObject.FindGameObjectsWithTag("ComplexSlot");

        foreach (var item in resultComplexSlotGo)
        {

            Destroy(item);
        }
    }
    public void ShowAndHide()
    {
        _visiblePanel = !_visiblePanel;
        _inventoryGO.SetActive(_visiblePanel);
        _clothingWeaponGo.SetActive(_visiblePanel);
    }
    public void UpdateDescriptionAndDetailPanel(GenericItemScriptable item)
    {
        if (_visiblePanel)
        {
            _itemText.text = $"Item: {item.name}";
            _typeText.text = $"Type: {item.ItemType.ToString()}";
            _descriptionText.text = $"Description: {item.Description}";

            _itemIconDetailPanel.sprite = item.Icon;
            _currentNumberText.text = item.CurrentNumber.ToString();
            _maxNumberText.text = _s + item.LimitedNumber.ToString();
            _totalWeightPerItemNumberText.text = item.TotalWeightPerItem.ToString() + _w;
        }
    }
    #endregion
}
