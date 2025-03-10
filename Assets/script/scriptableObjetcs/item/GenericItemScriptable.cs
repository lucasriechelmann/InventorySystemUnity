using System.Collections.Generic;
using UnityEngine;

public abstract class GenericItemScriptable : ScriptableObject
{
    #region Properties
    [SerializeField]
    int _id;
    [SerializeField]
    Sprite _icon;
    [SerializeField]
    bool _isDroppable;
    [SerializeField]
    bool _removeWhenNumberIsZero;
    [SerializeField]
    bool _isOnlyItem;
    [SerializeField]
    string _label;
    [SerializeField]
    [TextArea]
    string _description;
    [SerializeField]
    int _currentNumber;
    [SerializeField]
    int _limitedNumber;
    [SerializeField]
    [Range(1, 6)]
    int _slotSize;
    [SerializeField]
    float _weightPerItem;
    [SerializeField]
    float _totalWeightPerItem;
    [SerializeField]
    protected ActionManagerEvent _actionManagerEvent;
    [SerializeField]
    List<GenericActionScriptable> _actionUseList;

    #endregion
    #region Getter and Setters
    public int Id => _id;
    public Sprite Icon => _icon;
    public bool IsDroppable => _isDroppable;
    public bool RemoveWhenNumberIsZero => _removeWhenNumberIsZero;
    public bool IsOnlyItem => _isOnlyItem;
    public string Label => _label;
    public string Description => _description;
    public int CurrentNumber
    {
        get => _currentNumber;
        set => _currentNumber = value;
    }
    public int LimitedNumber => _limitedNumber;
    public int SlotSize => _slotSize;
    public float WeightPerItem => _weightPerItem;
    public float TotalWeightPerItem
    {
        get
        {
            UpdateWeight();
            return _totalWeightPerItem;
        }
    }
    #endregion
    #region Methods
    void OnEnable()
    {
        Reset();
        UpdateWeight();
    }
    public bool Add(int value)
    {
        if(IsOnlyItem)
        {
            CurrentNumber = 1;
            return true;
        }

        if(CurrentNumber + value <= LimitedNumber)
        {
            CurrentNumber += value;
            UpdateWeight();
            return true;
        }

        return false;
    }
    public bool Subtract(int value)
    {
        if (IsOnlyItem)
        {
            CurrentNumber = 0;
            return true;
        }
        if (CurrentNumber - value >= 0)
        {
            CurrentNumber -= value;
            UpdateWeight();
            return true;
        }
        return false;
    }
    public virtual bool Use(int value)
    {
        bool result = Subtract(value);

        if(result)
            ActionUseListDispatch();

        return result;
    }
    public virtual void ActionUseListDispatch()
    {
        _actionManagerEvent = new();
        _actionManagerEvent.DispatchAllGenericActionListEvent(_actionUseList);
    }
    public virtual void ActionEquipAndUnequipListDispatch()
    {

    }
    public void Reset()
    {
        _currentNumber = 0;
    }
    void UpdateWeight() => _totalWeightPerItem = _currentNumber * _weightPerItem;
    #endregion
}
