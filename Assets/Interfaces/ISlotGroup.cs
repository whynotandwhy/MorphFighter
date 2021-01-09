using System.Collections.Generic;
using UnityEngine.EventSystems;
public interface ISlotGroup : IPointerDownHandler, IDropHandler
{
    List<ISlot> slots { get; }
    bool NewInventoryRequest(IPart sourceSlot, ISlot destinationSlot);
    void ReturnItem(IPart part, ISlot sourceSlot);
}
