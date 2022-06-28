using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fluid", menuName = "Fluid")]
public class SubstanceFluid : ScriptableObject
{
    public Material material;

    public float percentageGoal;
    public float currentPercentage;
    public bool reachedGoal;

}
