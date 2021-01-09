
using System.Collections.Generic;

public interface IAbility
{
    /// <summary>
    /// number of slots required by this ablity
    /// </summary>
    int Count { get; }
    /// <summary>
    /// IAbilty has the collection of related components for it's calcuation
    /// keys are a 0 array index 
    /// </summary>
    /// <param name="index"> any integer, values ouside of range will be wraped</param>
    /// <returns> a slot reference see <seealso cref="ICombantant.ComponentParts"/> for possible values </returns>
    int this[int index] { get; }
    /// <summary>
    /// Calcates the cost given a specific Combatant 
    /// </summary>
    /// <param name="combatant"> a Combatant that will use the ability</param>
    /// <returns> the cost associated with the ablity to be applied to the combatant</returns>
    IAbilityEffect CalculateCost(ICombatant combatant);
    /// <summary>
    /// Calcates the payout given a specific Combatant 
    /// </summary>
    /// <param name="combatant"> a Combatant that will use the ability</param>
    /// <returns> the cost associated with the ablity to be applied to another combatant</returns>
    IAbilityEffect CalculatePayout(ICombatant combatant);
}
