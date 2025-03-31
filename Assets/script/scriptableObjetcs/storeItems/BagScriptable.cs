using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBag", menuName = "Inventory/Store Items/New Bag")]
public class BagScriptable : GenericBagScriptable
{
    #region Properties
    [SerializeField]
    [Range(1, 10)]
    protected int _maxShortCutSlots;
    [SerializeField]
    protected Dictionary<int, GenericItemScriptable> _itemsShortCutDictionary;
    #endregion
    #region Getter and Setters
    public int MaxShortCutSlots => _maxShortCutSlots;
    public Dictionary<int, GenericItemScriptable> ItemsShortCutDictionary => _itemsShortCutDictionary;
    #endregion
    #region Methods
    protected override void ResetBag()
    {
        base.ResetBag();
        _matrix = new(MaxRows, MaxColumns, "Bag");
    }
    #endregion
}
