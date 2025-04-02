using System;
using System.Collections.Generic;
using System.Linq;
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
    protected override void OnEnable()
    {
        _itemsShortCutDictionary = new();
        base.OnEnable();
    }
    protected override void ResetBag()
    {
        base.ResetBag();
        _matrix = new(MaxRows, MaxColumns, "Bag");
    }
    public override bool UseItem(int id, int value)
    {
        return base.UseItem(id, value);
    }
    public bool AddItemToShortCut(int index, GenericItemScriptable item)
    {
        if(_itemsShortCutDictionary.ContainsValue(item))
        {
            return false;
        }

        if (true)
        {
            _itemsShortCutDictionary.Add(index, item);
            return true;
        }

        return false;
    }
    public bool ChangeItemPosition(GenericItemScriptable item, int index)
    {
        if (_itemsShortCutDictionary.ContainsValue(item))
        {
            RemoveItemFromShortCutById(item.Id);
            AddItemToShortCut(index, item);
            return true;
        }

        return false;
    }
    public List<int> GetIdsFromItemShortCutDictionary()
    {
        List<int> resultIds = new();

        foreach(KeyValuePair<int, GenericItemScriptable> item in _itemsShortCutDictionary)
            resultIds.Add(item.Value.Id);

        return resultIds;
    }
    public List<int> GetUsedKeysFromShortCutDictionary()
    {
        List<int> resultIds = new();

        foreach(var item in _itemsShortCutDictionary)
            resultIds.Add(item.Key);

        return resultIds;
    }
    public GenericItemScriptable GetItemByIndexPosition(int index)
    {
        try
        {
            var result = _itemsShortCutDictionary.First(element => element.Key == index);

            if(!result.Equals(null))
            {
                return result.Value;
            }
        }
        catch
        {

        }

        return null;
    }
    public int GetIndexByItem(GenericItemScriptable item)
    {
        int resultIndex = -1;

        try
        {
            var result = _itemsShortCutDictionary.First(element => element.Value.Id == item.Id);

            if (!result.Equals(null))
            {
                resultIndex = result.Key;
            }
        }
        catch
        {

        }

        return resultIndex;
    }
    public bool RemoveItemFromShortCutById(int id)
    {
        try
        {
            var resultItem = _itemsShortCutDictionary.First(element => element.Value.Id == id);

            if(resultItem.Value != null)
            {
                _itemsShortCutDictionary.Remove(resultItem.Key);
                return true;
            }
        }
        catch
        {
            
        }

        return false;
    }
    #endregion
}
