using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PartDragger : IPartDragger
{
    public ISlot slot { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public IPart part { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    //Creates a resized part image and sets it to pointer position.
    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    //Updates the part image to the pointer position.
    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    //Clears part image and slot.
    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
