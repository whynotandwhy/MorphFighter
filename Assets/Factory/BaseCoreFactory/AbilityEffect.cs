using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Factory
{
    /// <summary>
    /// Simple Readonly Plain Old Common Object
    /// </summary>
    internal class AbilityEffect : IAbilityEffect
    {
        public float Concentration => concentration;
        internal float concentration;
        public float Energy => energy;
        internal float energy;
        public float HP => hP;
        internal float hP;
        internal AbilityEffect(float concentration, float energy, float hP)
        {
            this.concentration = concentration;
            this.energy = energy;
            this.hP = hP;
        }
    }
}
