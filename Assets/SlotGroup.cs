using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotGroup : MonoBehaviour, ISlotGroup
{
    protected PartDragger partDragger;
    protected List<ISlot> slots = new List<ISlot>();
    public List<ISlot> Slots => slots;
    protected ISlot sourceSlot;
    protected ISlot destinationSlot;
    protected IPart incomingPart;

    public PartDragger Dragger { get => partDragger; }

    /// <summary>
    /// This is called when we mouse down over a slot. It passes a slot reference and the item
    /// to the PartDragger, then clears the slot.
    /// </summary>
    /// <param name="slotSource"></param>
    public virtual void PickFromInventory(ISlot slotSource)
    {
        partDragger.SourcePart = slotSource.part;
        partDragger.SourceSlot = slotSource;
        slotSource.part = null;
    }

    /// <summary>
    /// This adds an item to the inventory if it is returning to its original position and confirms with
    /// the original inventory that the transfer is approved if not. This requires communicating with a
    /// PartDragger to find the sourceSlot in its current iteration. 
    /// </summary>
    public virtual void AddToInventory(IPart part, ISlot slotDestination = null)
    {
        //This could have an additional parameter for sourceSlot if we wanted to allow this to function
        //without a PartDragger if we wanted to utilize this code for gifted items from no inventory.

        SlotGroup slotGroup = (SlotGroup)partDragger.SourceSlot.mySlotGroup;

        if (slotGroup == this)
        {
            Debug.Log("A part is being returned.");
            AddItemToSlot(part, slotDestination);
            return;
        }

        if (slotGroup.NewInventoryRequest(part))
        {
            Debug.Log("A part is being added to the inventory.");
            AddItemToSlot(part, slotDestination);
            return;
        }

        Debug.Log("Part being returned to original slot.");
        slotGroup.AddItemToSlot(part, partDragger.SourceSlot);
    }

    /// <summary>
    /// Here we first assign the incomingPart and sourceSlot, then check if the drop is over a free slot. If so, we
    /// assign it to destinationSlot. If there is no slot, we call ReturnItem on the sourceSlot's Slot Group.
    /// If the drop location is valid, we call NewInventoryRequest on the sourceSlot Slot Group. If that
    /// returns true, we call AddToInventory here.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData) => AddToInventory(Dragger.SourcePart);

    /// <summary>
    /// This is an early implementation of grabbing the child slots. In the future the slot group
    /// should create and position each slot so they're in order.
    /// </summary>
    protected virtual void Awake()
    {
        if(partDragger == null)
            partDragger = FindObjectOfType<PartDragger>();

        foreach (Slot slot in this.GetComponentsInChildren<Slot>())
        {
            slots.Add(slot);
            slot.mySlotGroup = this;
        }
    }

    /// <summary>
    /// Here an Item Shop checks if the source slot is itself. If so, it then checks to see if the player
    /// can afford the item.If so, it then takes the money, clears the slot, and returns true. Else, it
    /// returns false. A player inventory will check to see if the destination slot is the item shop, then
    /// credit the player with the appropriate currency.
    /// </summary>
    /// <param name="sourceSlot"></param>
    /// <param name="destinationSlot"></param>
    /// <returns></returns>
    public virtual bool NewInventoryRequest(IPart sourcePart)
    {
        //Here is the condition each slotgroup uses to validate a transfer.
        return true;
    }
    
    /// <summary>
    /// This passes a part and slot to the SlotGroup, then checks where the part/slot came from
    /// to follow the appropriate checks before either adding the item or sending it back to 
    /// the original SlotGroup.
    /// </summary>
    /// <param name="part"></param>
    /// <param name="slotDestination"></param>
    protected virtual void AddItemToSlot(IPart part, ISlot slotDestination)
    {
        if (slotDestination != null && slotDestination.part == null)
        {
            slotDestination.part = part;
            partDragger.ClearPartDragger();
            return;
        }
        else
            foreach (Slot slot in slots)
                if (slot.part == null)
                {
                    Debug.Log("Found a slot for the drop.");
                    slot.part = part;
                    partDragger.ClearPartDragger();
                    return;
                }
        //Here we need some way to handle a full inventory.
        Debug.Log("No slot found. You should do something about that.");
    }
}
