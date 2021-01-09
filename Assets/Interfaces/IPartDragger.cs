using UnityEngine.EventSystems;
public interface IPartDragger : IDragHandler, IBeginDragHandler, IEndDragHandler
{
    ISlot slot { get; set; }
}
