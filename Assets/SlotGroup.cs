using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotGroup : MonoBehaviour, ISlotGroup
{
    protected PartDragger partDragger;
    protected List<Slot> slots = new List<Slot>();
    public List<Slot> Slots => slots;
    protected ISlot sourceSlot;
    protected ISlot destinationSlot;
    protected IPart incomingPart;

    public PartDragger Dragger { get => partDragger; }

    /// <summary>
    /// This is an early implementation of grabbing the child slots. In the future the slot group
    /// should create and align each slot so they're in order.
    /// </summary>
    protected void Awake()
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
    public virtual bool NewInventoryRequest(IPart sourcePart, ISlot destinationSlot)
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
    /// This finalizes the part transfer by moving the incomingPart to the destinationSlot.
    /// </summary>
    public void AddToInventory(IPart part, Slot slotDestination = null)
    {
        if (slotDestination != null)
        {
            slotDestination.part = part;
            Debug.Log(slotDestination.slotName + "'s part has " + slotDestination.part.Strength + " strength.");
            return;
        }

        else
            foreach (Slot slot in slots)
                if (slot.part == null)
                {
                    Debug.Log("Found a slot for the drop.");
                    slot.part = part;
                    return;
                }

        Debug.Log("No slot found. You should do something about that.");                    
    }

    public void PickFromInventory(ISlot slotSource)
    {
        partDragger.SourcePart = slotSource.part;
        partDragger.SourceSlot = slotSource;
        slotSource.part = null;
    }
}
