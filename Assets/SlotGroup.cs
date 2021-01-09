using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotGroup : MonoBehaviour, ISlotGroup
{
    public List<ISlot> slots => throw new System.NotImplementedException();
    protected ISlot sourceSlot;
    protected ISlot destinationSlot;
    protected IPart incomingPart;

    /// <summary>
    /// Here an Item Shop checks if the source slot is itself. If so, it then checks to see if the player
    /// can afford the item.If so, it then takes the money, clears the slot, and returns true. Else, it
    /// returns false. A player inventory will check to see if the destination slot is the item shop, then
    /// credit the player with the appropriate currency.
    /// </summary>
    /// <param name="sourceSlot"></param>
    /// <param name="destinationSlot"></param>
    /// <returns></returns>
    public bool NewInventoryRequest(IPart sourcePart, ISlot destinationSlot)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Here a part is returned to its original slot.
    /// </summary>
    /// <param name="part"></param>
    /// <param name="sourceSlot"></param>
    public void ReturnItem(IPart part, ISlot sourceSlot)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Here we first assign the incomingPart and sourceSlot, then check if the drop is over a free slot. If so, we
    /// assign it to destinationSlot. If there is no slot, we call ReturnItem on the sourceSlot's Slot Group.
    /// If the drop location is valid, we call NewInventoryRequest on the sourceSlot Slot Group. If that
    /// returns true, we call AddToInventory here.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Here we check to see if the pointer is over a slot and if so, we tell the PartDragger,
    /// by passing the Slot and its Part to it. We then clear the slot.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// This finalizes the part transfer by moving the incomingPart to the destinationSlot.
    /// </summary>
    public void AddToInventory()
    {
        throw new System.NotImplementedException();
    }
}
