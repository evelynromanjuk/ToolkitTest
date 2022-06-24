using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fluid", menuName = "Fluid")]
public class SubstanceFluid : ScriptableObject
{
    public float percentage;
    public Material material;
}
