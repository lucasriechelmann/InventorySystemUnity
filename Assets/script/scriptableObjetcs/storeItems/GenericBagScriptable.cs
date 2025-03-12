using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public abstract class GenericBagScriptable : ScriptableObject
{
    #region Properties
    [SerializeField]
    protected List<GenericItemScriptable> _itemList;
    [SerializeField]
    Sprite _icon;
    [SerializeField]
    string _title;
    [SerializeField]
    [Range(1, 10)]
    protected int maxColumns;
    [SerializeField]
    [Range(1, 10)]
    protected int maxRows;
    [SerializeField]
    protected int _currentSlot;
    [SerializeField]
    [Range(0.1f, 25f)]
    protected float _weightLimit;
    [SerializeField]
    protected float _currentWeight;
    [SerializeField]
    protected bool _autoOrganize;
    protected MatrixUtility _matrix;
    bool _usedOrganizeBySizePriority = false;
    #endregion
    #region Getter and Setters
    public Sprite Icon => _icon;
    public string Title => _title;
    public int MaxColumns => maxColumns;
    public int MaxRows => maxRows;
    public int CurrentSlot => _currentSlot;
    public float WeightLimit => _weightLimit;
    public float CurrentWeight => _currentWeight;
    public bool AutoOrganize => _autoOrganize;
    public bool UsedOrganizeBySizePriority
    {
        get => _usedOrganizeBySizePriority;
        set => _usedOrganizeBySizePriority = value;
    }
    public int SlotLimited => maxColumns * maxRows;

    #endregion
    #region Methods
    protected virtual void OnEnable()
    {
        ResetBag();
    }
    protected virtual bool SlotCapacityValidation(GenericItemScriptable item)
    {
        if(item.SlotSize == 2 || item.SlotSize == 3 || item.SlotSize == 5)
        {
            return !(item.SlotSize > MaxColumns && item.SlotSize > MaxRows);
        }

        return true;
    }
    protected virtual void OnDisable()
    {
    }
    protected virtual void ResetBag()
    {
        _itemList = new();
        _currentSlot = 0;
        _currentWeight = 0;
    }
    protected virtual bool SizeWeightNumberValidation(GenericItemScriptable item, int number, bool isNewItem)
    {
        if (isNewItem)
        {
            if(CurrentSlot + item.SlotSize <= SlotLimited)
            {
                if(_currentWeight + (item.WeightPerItem * number) <= _weightLimit)
                {
                    bool resultAdd = item.Add(number);

                    if (resultAdd)
                    {
                        UpdateSizeAndWeight();
                        
                    }

                    return resultAdd;
                }
                return false;
            }
            return false;
        }

        if(_currentWeight + (item.WeightPerItem * number) <= _weightLimit)
        {
            bool resultAdd = item.Add(number);
            if (resultAdd)
            {
                UpdateSizeAndWeight();
            }
            return resultAdd;
        }

        return false;
    }
    protected virtual void UpdateSizeAndWeight()
    {
        _currentSlot = 0;
        foreach(var item in _itemList)
        {
            _currentSlot += item.SlotSize;
            _currentWeight += item.TotalWeightPerItem;
        }
    }
    public virtual bool AddItem(GenericItemScriptable item, int number)
    {
        if(_itemList.Exists(x => x.Id == item.Id))
        {
            if(SizeWeightNumberValidation(item, number, false))
            {
                return true;
            }

            return false;
        }

        if(!SlotCapacityValidation(item))
            return false;

        List<Vector2> listResult = _matrix.LookForFreeArea(item.SlotSize);

        if(listResult.Count > 0)
        {
            if (SizeWeightNumberValidation(item, number, true))
            {
                _matrix.SetItem(listResult, item.Id);
                _itemList.Add(item);
                UpdateSizeAndWeight();
                return true;
            }
        }      
        
        if(_autoOrganize && SizeWeightNumberValidation(item, number, true))
        {
            _itemList.Add(item);
            UpdateSizeAndWeight();
            OrganizeBySizePriority();
            return true;
        }

        return false;
    }
    public virtual bool UseItem(int id, int value)
    {
        GenericItemScriptable item = FindItemById(id);

        if (item?.Use(value) ?? false)
            UpdateSizeAndWeight();

        return false;
    }
    public bool RemoveItem(int id)
    {
        GenericItemScriptable item = FindItemById(id);

        return RemoveItem(item);
    }
    public bool DropItem(int id)
    {
        GenericItemScriptable item = FindItemById(id);

        if (item != null && item.IsDroppable)
        {
            item.Reset();
            RemoveItem(item);
            return true;
        }

        return false;
    }
    public bool RemoveItem(GenericItemScriptable item)
    {
        if (item == null)
            return false;

        _matrix.ClearItemOnMatrix(item.Id);
        _itemList.Remove(item);
        UpdateSizeAndWeight();

        return true;
    }
    public GenericItemScriptable FindItemById(int id) => _itemList.Find(x => x.Id == id);
    public virtual void OrganizeBySizePriority()
    {
        _usedOrganizeBySizePriority = true;
        List<GenericItemScriptable> tempList = _itemList.OrderByDescending(x => x.SlotSize).ToList();
        ResetBag();
        _matrix.PopulateMatrix();
        foreach(GenericItemScriptable item in tempList)
        {
            AddItem(item, 0);
        }
    }
    public List<Vector2> FindCellById(int id) => _matrix.FindLocationById(id);
    public List<GenericItemScriptable> ReturnFullList() => _itemList;
    #endregion
}
