using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Factory
{
    [System.Serializable]
    internal class CombatStats : ICombatStats
    {
        public float Concentration => concentration;
        [SerializeField]internal float concentration;
        public float Consciousness => consciousness;
        [SerializeField] internal float consciousness;
        public float Energy => energy;
        [SerializeField] internal float energy;
        public float Stamina => stamina;
        [SerializeField] internal float stamina;

        public float HP => hP;
        [SerializeField] internal float hP;

        internal CombatStats(float concentration, float consciousness, float energy, float stamina, float hP)
        {
            this.concentration = concentration;
            this.consciousness = consciousness;
            this.energy = energy;
            this.stamina = stamina;
            this.hP = hP;
        }
        internal CombatStats(ICombatStats src, IAbilityEffect effect) : 
            this(src.Concentration,src.Consciousness,src.Energy, src.Stamina,src.HP)
        {
            ApplyAbilityEffect(effect);
        }

        public void ApplyRestoration(ICombatStats MaxValues)
        {
            this.concentration += this.Consciousness;
            this.concentration %= MaxValues.Concentration + 1;

            this.energy += this.stamina;
            this.energy %= MaxValues.Energy;
        }

        public void ApplyAbilityEffect(IAbilityEffect ability)
        {
            this.concentration += ability.Concentration;
            this.energy += ability.Energy;
            this.hP += ability.HP;
        }


    }
}
