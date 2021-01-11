using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSlot : Slot
{
    [SerializeField] protected Part newPart;
    [SerializeField] protected float focus;
    [SerializeField] protected float effort;
    [SerializeField] protected float strength;
    [SerializeField] protected int rank;

    [ContextMenu("Generate Part")]
    protected void GeneratePart()
    {
        newPart = new Part(focus, effort, strength, rank);
        part = newPart;
    }

    [ContextMenu("Announce Part Stats")]
    protected void AnnouncePartStats()
    {
        if(part == null)
        {
            Debug.Log("No part created.");
            return;
        }
        Debug.Log("Current part focus is: " + this.part.Focus);
        Debug.Log("Current part effort is: " + this.part.Effort);
        Debug.Log("Current part strength is: " + this.part.Strength);
        Debug.Log("Current part rank is: " + this.part.Rank);
    }
}
