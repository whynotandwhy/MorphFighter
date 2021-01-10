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
    }
}
