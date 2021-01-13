using System.Collections.Generic;

/// <summary>
/// ICombatant is a summation of the player information  
/// </summary>
public interface ICombatant 
{
    /// <summary>
    /// Caclated starting values for a combatant 
    /// </summary>
    ICombatStats StartingCombats { get; }
    /// <summary>
    /// Caculated Max values for a combatant 
    /// </summary>
    ICombatStats MaxCombatStats { get; }

    /// <summary>
    /// Specfic Components
    /// 0 - head
    /// 1 - torso
    /// 2 - Left Arm
    /// 3 - Right Arm
    /// 4 - Left Leg
    /// 5 - Right Leg
    /// </summary>
    IReadOnlyDictionary<int, IAbilityEffect> ComponentParts { get; }

    /// <summary>
    /// This gives us a way to reset the starting values for CombatStats 
    /// </summary>
    /// <param name="partList"></param>
    void SetComponentParts(IEnumerable<KeyValuePair<int, IAbilityEffect>> partList);

    /// <summary>
    /// The abilities available to this combatant
    /// </summary>
    IEnumerable<IAbility> Abilities { get; }

}
