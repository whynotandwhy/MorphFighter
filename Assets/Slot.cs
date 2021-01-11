using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, ISlot
{
    public string slotName;

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
    }

    /// <summary>
    /// This should go to the Slot Group associated with this and either call NewInventoryRequest
    /// or return the item depending on the circumstances.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData)
    {
        //mySlotGroup.NewInventoryRequest(part, this);
        mySlotGroup.AddToInventory(mySlotGroup.Dragger.SourcePart, this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Disappointing dad.");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("YASSSSS queen, drag her!"); 
        this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        Debug.Log("Scaring the straight guy.");
    }
}
