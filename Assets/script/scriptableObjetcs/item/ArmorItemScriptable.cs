using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewArmorItem", menuName = "Inventory/Items/New Armor Item")]
public class ArmorItemScriptable : GenericItemScriptable
{
    [SerializeField]
    List<GenericActionScriptable> _actionEquipList;

    public override void ActionEquipAndUnequipListDispatch()
    {
        _actionManagerEvent = new();        
        _actionManagerEvent.DispatchAllGenericActionListEvent(_actionEquipList);

    }
}
