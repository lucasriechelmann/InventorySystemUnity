using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewWeaponItem", menuName = "Inventory/Items/New Weapon Item")]
public class WeaponItemScriptable : GenericItemScriptable
{
    [SerializeField]
    List<GenericActionScriptable> _actionEquipList;
    public override void ActionEquipAndUnequipListDispatch()
    {
        _actionManagerEvent = new();
        _actionManagerEvent.DispatchAllGenericActionListEvent(_actionEquipList);
    }
}
