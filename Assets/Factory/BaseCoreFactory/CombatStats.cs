using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Factory
{
    internal class CombatStats : ICombatStats
    {
        public float Concentration => concentration;
        internal float concentration;
        public float Consciousness => consciousness;
        internal float consciousness;
        public float Energy => energy;
        internal float energy;
        public float Stamina => stamina;
        internal float stamina;

        public float HP => hP;
        internal float hP;

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
