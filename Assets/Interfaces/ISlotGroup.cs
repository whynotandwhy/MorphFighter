using System.Collections.Generic;
using UnityEngine.EventSystems;
public interface ISlotGroup : IPointerDownHandler, IDropHandler
{
    List<ISlot> slots { get; }
    bool NewInventoryRequest(ISlot sourceSlot, ISlot destinationSlot);
    void UpdateInventory(ISlot newSlot);
}
