using UnityEngine;

[CreateAssetMenu(fileName = "NewBag", menuName = "Inventory/Store Items/New Bag")]
public class BagScriptable : GenericBagScriptable
{
    protected override void ResetBag()
    {
        base.ResetBag();
        _matrix = new(MaxRows, MaxColumns, "Bag");
    }
}
