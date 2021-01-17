using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICoreFactory
{
    IAbility FindAbility(int ablityID);
    IAbility FindAbility(string ablityName);
    IAbilityEffect NewAbilityEffect(float Concentration, float Energy, float HP);
    ICombatant NewCombatant(IEnumerable<KeyValuePair<int, IPart>> components, IEnumerable<IAbility> abilites);
    ICombatStats NewCombatStats(float concentration, float consciousness, float energy, float stamina, float hP);
    ICombatStats NewCombatStats(ICombatStats source, IAbilityEffect abilityEffect);
    IPart NewPart(float focus, float effort, float strength);
}
