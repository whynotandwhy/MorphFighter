using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotGroup : MonoBehaviour, ISlotGroup
{
    public List<ISlot> slots => throw new System.NotImplementedException();
    protected ISlot reservedSlot;
    protected ISlot incomingSlot;   

    /*Here an Item Shop checks if the source slot is itself. If so, it then checks to see if the player
     can afford the item. If so, it then takes the money, clears the slot, and returns true. Else, it 
    returns false. A player inventory will check to see if the destination slot is the item shop, then
    credit the player with the appropriate currency.*/
    public bool NewInventoryRequest(ISlot sourceSlot, ISlot destinationSlot)
    {
        throw new System.NotImplementedException();
    }

    /*Here we first assign the incomingSlot, then check if the drop is over a free slot. If so, we
     assign it to reservedSlot. If there is no slot, we call UpdateInventory on the source SlotGroup.
    If the drop location is a free slot, we call NewInventoryRequest on the source slot. If that 
    returns true, we call UpdateInventory here.*/
    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
    
    /*Here we check to see if the pointer is over a slot and if so, we tell the PartDragger,
     then we temporarily disable the image of that slot.*/
    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    /*Here, assign any incomingSlot parts to reservedSlots, then iterate through items to ensure all
     items are visible in their slots (due to them being disabled when we drag them).*/
    public void UpdateInventory(ISlot newSlot)
    {
        throw new System.NotImplementedException();
    }
}
