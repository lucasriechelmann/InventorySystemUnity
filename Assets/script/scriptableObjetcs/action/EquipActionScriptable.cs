using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEquipAction", menuName = "Action/New Equip Action")]
public class EquipActionScriptable : GenericActionScriptable
{
    [SerializeField]
    ItemEquip _itemEquip;
    public override IEnumerator Execute()
    {
        yield return new WaitForSeconds(DelayToStart);

        //GameController >> Show popup
    }
}