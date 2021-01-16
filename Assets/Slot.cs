using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, ISlot
{
    protected Part slotPart = null;
    public SlotGroup mySlotGroup { get; set; }
    public IPart part { get => slotPart; set => slotPart = value as Part; }

    /// <summary>
    /// Here we check to see if the pointer is over a slot and if so, we tell the PartDragger,
    /// by passing the Slot and its Part to it. We then clear the slot.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        if(part != null)
        {
            Debug.Log("Part selected.");
            mySlotGroup.PickFromInventory(this);
        }
        else
        {
            Debug.Log("No part in this slot.");
        }
    }

    /// <summary>
    /// This will need to likely implement some kind of CanvasGroup().blocksRaycasts = false; unless
    /// the default image we populate in the PartDragger doesn't block raycasts by default.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        //this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Disappointing dad.");
    }

    /// <summary>
    /// This goes to the Slot Group associated with the slot under the pointer and either call NewInventoryRequest
    /// or return the item depending on the circumstances.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData)
    {
        mySlotGroup.AddToInventory(mySlotGroup.Dragger.SourcePart, this);
    }

    /// <summary>
    /// This checks to see if we still the Dragger still has a part (meaning we didn't drop it in an appropriate slot 
    /// or slot group), and if so, returns the part to this slot.
    /// This will need to likely implement some kind of CanvasGroup().blocksRaycasts = true; unless
    /// the default image we populate in the PartDragger doesn't block raycasts by default. 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        //this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (mySlotGroup.Dragger.SourcePart != null || mySlotGroup.Dragger.SourceSlot != null)
            mySlotGroup.AddToInventory(mySlotGroup.Dragger.SourcePart, this);
    }
}
