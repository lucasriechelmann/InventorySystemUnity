using UnityEngine;

public class SimpleSlotView : MonoBehaviour
{
    [SerializeField]
    SlotPlaceTo _slotPlaceTo;
    [SerializeField]
    Vector2 _coordinate;
    public SlotPlaceTo SlotPlaceTo { get => _slotPlaceTo; set => _slotPlaceTo = value; }
    public Vector2 Coordinate { get => _coordinate; set => _coordinate = value; }
}
