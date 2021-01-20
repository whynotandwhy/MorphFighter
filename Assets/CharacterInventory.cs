using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Factory;

public class CharacterInventory : SlotGroup
{
    protected CharacterStatUpdater characterStatUpdater;
    protected ICombatant currentCombatant;
    protected ICombatant predictedCombatant;

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

    public void Start()
    {
         characterStatUpdater.UpdateUI(FactoryConfig.CoreFactory.NewCombatStats(.1f,.3f,.4f,.5f,1));
    }

    protected override void AddItemToSlot(IPart part, ISlot slotDestination)
    {
        base.AddItemToSlot(part, slotDestination);

        // Here we need to update the character stats.

        //TODO: there should be some assoation based in the slots themselves to identify which slock they are in.
        List<KeyValuePair<int, IPart>> newitems = new List<KeyValuePair<int, IPart>>();
        int index = 0;
        foreach (ISlot partialList in this.Slots)
            newitems.Add(new KeyValuePair<int, IPart>(index++, partialList.part));

        currentCombatant.SetComponentParts(newitems);
        characterStatUpdater.UpdateUI(currentCombatant.StartingCombats);
    }
}
