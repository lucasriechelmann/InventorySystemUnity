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
    #endregion
}
