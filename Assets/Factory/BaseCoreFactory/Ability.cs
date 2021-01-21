using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Factory
{

    [System.Serializable]
    internal class Ability : MonoBehaviour,  IAbility
    {
        [System.Serializable]
        public class Setting { public ComponentIds Slot; [SerializeField] protected CombatStats combatStats; public ICombatStats relatedStats; }

        [SerializeField] protected List<Setting> Concentration = new List<Setting>();
        
        
        public int this[int index] => throw new System.NotImplementedException();

        public int Count => throw new System.NotImplementedException();

        public IAbilityEffect CalculateCost(ICombatant combatant)
        {
            throw new System.NotImplementedException();
        }

        public IAbilityEffect CalculatePayout(ICombatant combatant)
        {
            throw new System.NotImplementedException();
        }
    }
}
