using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Factory
{
    internal class Part : IPart
    {
        internal float focus;
        public float Focus => focus;
        internal float effort;
        public float Effort => effort;
        internal float strength;
        public float Strength => strength;
        internal int rank;
        public int Rank => rank;

        internal Part(float focus, float effort, float strength, int rank)
        {
            this.focus = focus;
            this.effort = effort;
            this.strength = strength;
            this.rank = rank;
        }
    }
}
