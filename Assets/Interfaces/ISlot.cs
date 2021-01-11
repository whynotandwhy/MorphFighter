using UnityEngine.EventSystems;
public interface ISlot : IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    SlotGroup mySlotGroup { get; set; }
    IPart part { get; set; }
}
