using UnityEngine;

[CreateAssetMenu(fileName = "NewConsumableItem", menuName = "Inventory/Items/New Consumable Item")]
public class ConsumableItemScriptable : GenericItemScriptable
{
    public override ItemType ItemType => ItemType.CONSUMABLE;
}
