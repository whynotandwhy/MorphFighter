using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class PartDragger : MonoBehaviour, IPartDragger
{
    [SerializeField] protected Image dragImage;

    protected Slot sourceSlot;
    protected Part sourcePart;
    public ISlot SourceSlot { get => sourceSlot; set => sourceSlot = value as Slot; }
    public IPart SourcePart { get => sourcePart; set => sourcePart = value as Part; }

    public void ClearPartDragger()
    {
        sourcePart = null;
        sourceSlot = null;
    }
}
