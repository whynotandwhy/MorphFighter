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

        public IAbilityEffect NewAbilityEffect(float Concentration, float Energy, float HP)
        {
            throw new System.NotImplementedException();
        }

        public ICombatant NewCombatant(IEnumerable<IPart> components, IEnumerable<IAbility> abilites)
        {
            throw new System.NotImplementedException();
        }

        public ICombatStats NewCombatStats()
        {
            throw new System.NotImplementedException();
        }

        public ICombatStats NewCombatStats(ICombatStats source, IAbilityEffect abilityEffect)
        {
            throw new System.NotImplementedException();
        }

        public IPart NewPart(float focus, float effort, float strength)
        {
            return new Part(focus, effort, strength, (int)((focus + effort + strength) / 3));
        }
    }
}
