using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidManager : MonoBehaviour
{
    public SubstanceFluid substanceFluid;

    Action<string, int> FluidFlowingEvent;

    private float goalPercentage;
    private float totalTime = 40.0f; //seconds
    private float currentPercentage = 0.0f;
    private float size = 0.0f;

    void Start()
    {
        GetComponent<Renderer>().material = substanceFluid.material;
        goalPercentage = substanceFluid.percentage;
    }

    public void openTube()
    {
        InvokeRepeating("Scale", 0.0f, 0.02f);

        InvokeRepeating("IncreaseFluidAmount", 0.0f, 1.0f);

    }

    void Scale()
    {
        if (size >= 100.0f)
        {
            CancelInvoke("Scale");
        }

        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, size++);
    }

    void IncreaseFluidAmount()
    {
        currentPercentage += (100.0f / totalTime);
        Debug.Log("CurrentPercentage: " + currentPercentage);

        if (currentPercentage >= goalPercentage)
            CancelInvoke("IncreaseFluidAmount");
    }

    public void SubscribeFluidChange(Action<string, int> method)
    {
        FluidFlowingEvent += method;
    }

}
