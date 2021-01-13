using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Factory
{
    internal class Combatant : ICombatant
    {
        public ICombatStats StartingCombats => startingCombats;
        protected CombatStats startingCombats;
        public ICombatStats MaxCombatStats => maxCombatStats;
        protected CombatStats maxCombatStats;
        public IReadOnlyDictionary<int, IAbilityEffect> ComponentParts => componentParts;
        protected Dictionary<int, IAbilityEffect> componentParts; 
        public IEnumerable<IAbility> Abilities => abilities;
        protected List<IAbility> abilities;

        internal Combatant(IEnumerable<IAbility>abilities, IReadOnlyDictionary<int, IAbilityEffect> partList = default)
        {
            abilities = (abilities == default) ? new List<IAbility>() : new List<IAbility>(abilities);
            componentParts = (partList == default) ? new Dictionary<int, IAbilityEffect>() : new Dictionary<int, IAbilityEffect>(partList);
        }

        public void SetComponentParts(IEnumerable<KeyValuePair<int, IAbilityEffect>> partList)
        {
            throw new System.NotImplementedException();
        }

        internal CombatStats CalculateStartingCombatStats()
        {
            return FactoryConfig.CoreFactory.NewCombatStats(1, 1, 1, 1, 1) as CombatStats;
        }

        internal CombatStats CalcateMaxCombatStats()
        {
            return FactoryConfig.CoreFactory.NewCombatStats(1, 1, 1, 1, 1) as CombatStats;
        }
    }
}
