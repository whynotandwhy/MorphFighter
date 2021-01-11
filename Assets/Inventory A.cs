using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryA : SlotGroup
{
    public override bool NewInventoryRequest(IPart sourcePart, ISlot destinationSlot)
    {
        return false;
    }
}
