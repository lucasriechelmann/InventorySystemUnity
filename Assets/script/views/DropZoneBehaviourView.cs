using UnityEngine;
using UnityEngine.EventSystems;
public class DropZoneBehaviourView : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invPanel = transform as RectTransform;

        if(!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
            return;
        }

        GameObject gameObjectResult = eventData.pointerDrag;
        GenericItemScriptable itemResult = gameObjectResult.GetComponent<ComplexSlotView>().ItemView;
        SimpleSlotView simpleSlotView = GetComponent<SimpleSlotView>();
        Vector2 coordinate = simpleSlotView.Coordinate;
        SlotPlaceTo slotPlaceTo = simpleSlotView.SlotPlaceTo;

        bool result = InventoryManagerController.Instance.OnDropItem(itemResult, gameObjectResult, coordinate, slotPlaceTo);

        if(result)
        {

        }
    }
}
