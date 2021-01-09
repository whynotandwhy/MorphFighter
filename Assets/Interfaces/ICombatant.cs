using System.Collections.Generic;

/// <summary>
/// ICombatant is a summation of the player information  
/// </summary>
public interface ICombatant 
{
    /// <summary>
    /// Caclated starting values for a combatant 
    /// </summary>
    ICombatStats CombatStats { get; }
    /// <summary>
    /// Specfic Components
    /// 0 - head
    /// 1 - torso
    /// 2 - Left Arm
    /// 3 - Right Arm
    /// 4 - Left Leg
    /// 5 - Right Leg
    /// </summary>
    IEnumerable<IPart> ComponentParts { get; }
    /// <summary>
    /// The abilities available to this combatant
    /// </summary>
    IEnumerable<IAbility> Abilities { get; }
}
