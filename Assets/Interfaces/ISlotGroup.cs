using System.Collections.Generic;
using UnityEngine.EventSystems;
public interface ISlotGroup : IDropHandler
{
    List<ISlot> Slots { get; }
    void AddToInventory(IPart part, ISlot slotDestination = null);
    void PickFromInventory(ISlot slotSource);

}
