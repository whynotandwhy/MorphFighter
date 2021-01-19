using UnityEngine.EventSystems;
public interface ISlot : IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    ISlotGroup mySlotGroup { get; set; }
    IPart part { get; set; }
}
