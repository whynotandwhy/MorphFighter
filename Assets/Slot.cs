using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour, ISlot
{
    public ISlotGroup mySlotGroup { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public IPart part { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

}
