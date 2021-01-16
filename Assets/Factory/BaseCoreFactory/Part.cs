using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Factory
{
    internal class Part : IPart
    {
        public float Focus => focus;
        internal float focus;
        public float Effort => effort;
        internal float effort;
        public float Strength => strength;
        internal float strength;
        public int Rank => rank;
        internal int rank;


        internal Part(float focus, float effort, float strength, int rank)
        {
            this.focus = focus;
            this.effort = effort;
            this.strength = strength;
            this.rank = rank;
        }
    }
}
