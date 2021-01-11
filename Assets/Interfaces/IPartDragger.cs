using UnityEngine.EventSystems;
public interface IPartDragger
{
    ISlot SourceSlot { get; set; }
    IPart SourcePart { get; set; }
}
