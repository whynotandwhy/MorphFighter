using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : SlotGroup
{
    protected CharacterStatUpdater characterStatUpdater;

    public override bool NewInventoryRequest(IPart sourcePart)
    {
        // This should almost always return true, with the exception that we may oneday implement some kind of lock.
        return true;
    }

    public override void PickFromInventory(ISlot slotSource)
    {
        base.PickFromInventory(slotSource);

        //Here we need to update character stats.
    }

    public override void AddToInventory(IPart part, ISlot slotDestination = null)
    {
        base.AddToInventory(part, slotDestination);
    }

    protected override void Awake()
    {
        if (characterStatUpdater == null)
            characterStatUpdater = FindObjectOfType<CharacterStatUpdater>();

        base.Awake();
    }

    protected override void AddItemToSlot(IPart part, ISlot slotDestination)
    {
        base.AddItemToSlot(part, slotDestination);

        // Here we need to update the character stats.
    }
}
