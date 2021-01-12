using System.Collections.Generic;
using UnityEngine.EventSystems;
public interface ISlotGroup : IDropHandler
{
    List<Slot> Slots { get; }
    bool NewInventoryRequest(IPart sourceSlot);
    void AddToInventory(IPart part, Slot slotDestination = null);
    void PickFromInventory(ISlot slotSource);

}
