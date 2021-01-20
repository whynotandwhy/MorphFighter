using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : SlotGroup
{
    public override bool NewInventoryRequest(IPart sourcePart)
    {
        // There may need to be a check here in the future, but for now all transfers should be true.
        return true;
    }

    public override void PickFromInventory(ISlot slotSource) => base.PickFromInventory(slotSource);
    public override void AddToInventory(IPart part, ISlot slotDestination = null) => base.AddToInventory(part, slotDestination);
    protected override void AddItemToSlot(IPart part, ISlot slotDestination) => base.AddItemToSlot(part, slotDestination);
}
