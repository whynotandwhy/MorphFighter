using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Factory
{
    [CreateAssetMenu(fileName = "BaseCoreFactory", menuName = "ScriptableObjects/BaseCoreFactory", order = 1)]
    public class BaseCoreFactory : ScriptableObject, ICoreFactory
    {
        public IAbility FindAbility(int ablityID)
        {
            throw new System.NotImplementedException();
        }

        public IAbility FindAbility(string ablityName)
        {
            throw new System.NotImplementedException();
        }

        public IAbilityEffect NewAbilityEffect(float concentration, float energy, float hP)
        {
            return new AbilityEffect(concentration, energy, hP);
        }

        public ICombatant NewCombatant(IEnumerable<KeyValuePair<int, IPart>> components, IEnumerable<IAbility> abilites)
        {
            return new Combatant(abilites, components);
        }

        public ICombatStats NewCombatStats(float concentration, float consciousness, float energy, float stamina, float hP)
        {
            return new CombatStats(concentration, consciousness, energy, stamina, hP);
        }

        public ICombatStats NewCombatStats(ICombatStats source, IAbilityEffect abilityEffect)
        {
            return new CombatStats(source, abilityEffect);
        }

        public IPart NewPart(float focus, float effort, float strength)
        {
            return new Part(focus, effort, strength, (int)((focus + effort + strength) / 3));
        }
    }
}
