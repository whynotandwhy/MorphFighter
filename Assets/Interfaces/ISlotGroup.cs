using System.Collections.Generic;
public interface ISlotGroup 
{
    List<ISlot> slots { get; set; }

    bool newInventoryRequest(ISlot sourceSlot, ISlot destinationSlot);
}
