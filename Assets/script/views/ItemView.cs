using System.Collections.Generic;
using UnityEngine;

public class ItemView : MonoBehaviour
{
    #region Properties
    [SerializeField]
    int _number;
    [SerializeField]
    GenericItemScriptable _item;
    [SerializeField]
    List<GenericActionScriptable> _actionList;
    ActionManagerEvent _actionManagerEvent;
    #endregion
    #region Getter and Setters
    public int Number 
    {
        get => _number;
        set => _number = value;
    }
    public GenericItemScriptable Item => _item;
    #endregion
    #region Methods
    void OnMouseDown() => Collect();
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            Collect();         
    }
    void Collect()
    {
        bool result = InventoryManagerController.Instance.AddItemToCurrentBag(_item, _number, false);

        if (result)
        {
            _actionManagerEvent = new();
            _actionManagerEvent.DispatchAllGenericActionListEvent(_actionList);
            Destroy(gameObject);
        }
    }
    #endregion
}
