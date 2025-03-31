using UnityEngine;
[CreateAssetMenu(fileName = "NewQuestItem", menuName = "Inventory/Items/New Quest Item")]
public class QuestItemScriptable : GenericItemScriptable
{
    public override ItemType ItemType => ItemType.QUEST;
}
