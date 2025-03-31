using UnityEngine;
using UnityEngine.EventSystems;
public class PointDownBehaviourView : MonoBehaviour, IPointerDownHandler
{
    ComplexSlotView _complexSlotView;
    void Awake()
    {
        _complexSlotView = GetComponent<ComplexSlotView>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        GenericItemScriptable item = _complexSlotView.ItemView;
        InventoryManagerController.Instance.OnPointerDownItem(item, gameObject);

    }
}
