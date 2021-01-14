using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace Factory
{
    internal class Combatant : ICombatant
    {
        public ICombatStats StartingCombats => startingCombats;
        protected CombatStats startingCombats;
        public ICombatStats MaxCombatStats => maxCombatStats;
        protected CombatStats maxCombatStats;
        public IReadOnlyDictionary<int, IPart> ComponentParts => componentParts;
        protected Dictionary<int, IPart> componentParts; 
        public IEnumerable<IAbility> Abilities => abilities;
        protected List<IAbility> abilities;

        internal Combatant(IEnumerable<IAbility>abilities, IReadOnlyDictionary<int, IPart> partList = default)
        {
            abilities = (abilities == default) ? new List<IAbility>() : new List<IAbility>(abilities);
            componentParts = new Dictionary<int, IPart>();
        }

        public void SetComponentParts(IEnumerable<KeyValuePair<int, IPart>> partList)
        {
            componentParts.Clear();
            if (partList != default)
                partList.Select(x => { componentParts.Add(x.Key, x.Value); return x; }) ;

            startingCombats = CalculateStartingCombatStats();
            maxCombatStats = CalculateMaxCombatStats();

        }


        float Focus { get; }
        float Effort { get; }
        float Strength { get; }

        internal Dictionary<int, ICombatStats> startingValuesStatsFocus = new Dictionary<int, ICombatStats>()
        {
            {1, FactoryConfig.CoreFactory.NewCombatStats(0,0,2,0,0) },
            {2, FactoryConfig.CoreFactory.NewCombatStats(0.1f,0,0,0,0) },
            {3, FactoryConfig.CoreFactory.NewCombatStats(0.1f,0,0,0,0) },
            {4, FactoryConfig.CoreFactory.NewCombatStats(0.1f,0,0,0,0) },
            {5, FactoryConfig.CoreFactory.NewCombatStats(0.1f,0,0,0,0) }
        };
        internal Dictionary<int, ICombatStats> startingValuesStatsEffort = new Dictionary<int, ICombatStats>()
        {
            {0, FactoryConfig.CoreFactory.NewCombatStats(0,1,0,0,0) },
            {1, FactoryConfig.CoreFactory.NewCombatStats(0,0,0,1,0) },
            {2, FactoryConfig.CoreFactory.NewCombatStats(0,0,1,0,0) },
            {3, FactoryConfig.CoreFactory.NewCombatStats(0,0,1,0,0) },
            {4, FactoryConfig.CoreFactory.NewCombatStats(0,0,1,0,0) },
            {5, FactoryConfig.CoreFactory.NewCombatStats(0,0,1,0,0) }
        };
        internal Dictionary<int, ICombatStats> startingValuesStatsStrength = new Dictionary<int, ICombatStats>()
        {
            {0, FactoryConfig.CoreFactory.NewCombatStats(2,0,0,0,0) },
            {1, FactoryConfig.CoreFactory.NewCombatStats(0,0,0,0,50) },
            {2, FactoryConfig.CoreFactory.NewCombatStats(0,0,0,0,5) },
            {3, FactoryConfig.CoreFactory.NewCombatStats(0,0,0,0,5) },
            {4, FactoryConfig.CoreFactory.NewCombatStats(0,0,0,0,5) },
            {5, FactoryConfig.CoreFactory.NewCombatStats(0,0,0,0,5) }
       };
        internal Dictionary<int, ICombatStats> MaxValuesFocus = new Dictionary<int, ICombatStats>()
        {
            {0, FactoryConfig.CoreFactory.NewCombatStats(5,0,0,0,0) },
        };
        internal Dictionary<int, ICombatStats> MaxValuesEffort = new Dictionary<int, ICombatStats>()
        {
            {2, FactoryConfig.CoreFactory.NewCombatStats(0,0,1,0,0) },
            {3, FactoryConfig.CoreFactory.NewCombatStats(0,0,1,0,0) },
            {4, FactoryConfig.CoreFactory.NewCombatStats(0,0,1,0,0) },
            {5, FactoryConfig.CoreFactory.NewCombatStats(0,0,1,0,0) }
        };
        internal Dictionary<int, ICombatStats> MaxValuesStrength = new Dictionary<int, ICombatStats>()
        {
            {1, FactoryConfig.CoreFactory.NewCombatStats(0,0,0,0,50) },
            {2, FactoryConfig.CoreFactory.NewCombatStats(0,0,0,0,5) },
            {3, FactoryConfig.CoreFactory.NewCombatStats(0,0,0,0,5) },
            {4, FactoryConfig.CoreFactory.NewCombatStats(0,0,0,0,5) },
            {5, FactoryConfig.CoreFactory.NewCombatStats(0,0,0,0,5) }
        };

        internal CombatStats CalculateStartingCombatStats()
        {
            float concentration = 0;
            float consciousness = 0;
            float energy = 0;
            float stamina = 0;
            float hP = 0;

            foreach (KeyValuePair<int, ICombatStats> sloteffect in startingValuesStatsFocus)
            {
                IPart sourceComponent;
                if (!componentParts.TryGetValue(sloteffect.Key, out sourceComponent))
                    continue;
                float sourceValue = sourceComponent.Focus;
                concentration += sloteffect.Value.Concentration * sourceValue;
                consciousness += sloteffect.Value.Consciousness * sourceValue;
                energy += sloteffect.Value.Energy * sourceValue;
                stamina += sloteffect.Value.Stamina * sourceValue;
                hP += sloteffect.Value.HP * sourceValue;
            }

            foreach (KeyValuePair<int, ICombatStats> sloteffect in startingValuesStatsEffort)
            {
                IPart sourceComponent;
                if (!componentParts.TryGetValue(sloteffect.Key, out sourceComponent))
                    continue;
                float sourceValue = sourceComponent.Effort;
                concentration += sloteffect.Value.Concentration * sourceValue;
                consciousness += sloteffect.Value.Consciousness * sourceValue;
                energy += sloteffect.Value.Energy * sourceValue;
                stamina += sloteffect.Value.Stamina * sourceValue;
                hP += sloteffect.Value.HP * sourceValue;
            }
            foreach (KeyValuePair<int, ICombatStats> sloteffect in startingValuesStatsStrength)
            {
                IPart sourceComponent;
                if (!componentParts.TryGetValue(sloteffect.Key, out sourceComponent))
                    continue;
                float sourceValue = sourceComponent.Strength;
                concentration += sloteffect.Value.Concentration * sourceValue;
                consciousness += sloteffect.Value.Consciousness * sourceValue;
                energy += sloteffect.Value.Energy * sourceValue;
                stamina += sloteffect.Value.Stamina * sourceValue;
                hP += sloteffect.Value.HP * sourceValue;
            }

            return FactoryConfig.CoreFactory.NewCombatStats(concentration, consciousness, energy, stamina, hP) as CombatStats;
        }



        internal CombatStats CalculateMaxCombatStats()
        {
            float concentration = 0;
            float consciousness = 0;
            float energy = 0;
            float stamina = 0;
            float hP = 0;

            foreach (KeyValuePair<int, ICombatStats> sloteffect in MaxValuesFocus)
            {
                IPart sourceComponent;
                if (!componentParts.TryGetValue(sloteffect.Key, out sourceComponent))
                    continue;
                float sourceValue = sourceComponent.Focus;
                concentration += sloteffect.Value.Concentration * sourceValue;
                consciousness += sloteffect.Value.Consciousness * sourceValue;
                energy += sloteffect.Value.Energy * sourceValue;
                stamina += sloteffect.Value.Stamina * sourceValue;
                hP += sloteffect.Value.HP * sourceValue;
            }

            foreach (KeyValuePair<int, ICombatStats> sloteffect in MaxValuesEffort)
            {
                IPart sourceComponent;
                if (!componentParts.TryGetValue(sloteffect.Key, out sourceComponent))
                    continue;
                float sourceValue = sourceComponent.Effort;
                concentration += sloteffect.Value.Concentration * sourceValue;
                consciousness += sloteffect.Value.Consciousness * sourceValue;
                energy += sloteffect.Value.Energy * sourceValue;
                stamina += sloteffect.Value.Stamina * sourceValue;
                hP += sloteffect.Value.HP * sourceValue;
            }
            foreach (KeyValuePair<int, ICombatStats> sloteffect in MaxValuesStrength)
            {
                IPart sourceComponent;
                if (!componentParts.TryGetValue(sloteffect.Key, out sourceComponent))
                    continue;
                float sourceValue = sourceComponent.Strength;
                concentration += sloteffect.Value.Concentration * sourceValue;
                consciousness += sloteffect.Value.Consciousness * sourceValue;
                energy += sloteffect.Value.Energy * sourceValue;
                stamina += sloteffect.Value.Stamina * sourceValue;
                hP += sloteffect.Value.HP * sourceValue;
            }

            return FactoryConfig.CoreFactory.NewCombatStats(concentration, consciousness, energy, stamina, hP) as CombatStats;
        }
    }
}
