using System.Collections.Generic;
using UnityEngine.EventSystems;
public interface ISlotGroup : IDropHandler
{
    List<Slot> Slots { get; }
    bool NewInventoryRequest(IPart sourceSlot, ISlot destinationSlot);
    void ReturnItem(IPart part, ISlot sourceSlot);
    void AddToInventory(IPart part, Slot slotDestination = null);
    void PickFromInventory(ISlot slotSource);

}
