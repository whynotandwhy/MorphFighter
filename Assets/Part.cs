using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Part : IPart
{
    public float Focus { get; set; }
    public float Effort { get; set; }
    public float Strength { get; set; }
    public int Rank { get; set; }

    public Part(float focus, float effort, float strength, int rank)
    {
        Focus = focus;
        Effort = effort;
        Strength = strength;
        Rank = rank;
    }
}
