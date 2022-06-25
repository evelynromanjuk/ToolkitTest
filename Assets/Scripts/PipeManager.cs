using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    public SubstanceFluid substanceFluid;

    // Action<string, int> FluidFlowingEvent;

    public FluidCompositionManager FluidCompositionManager;

    private float goalPercentage;
    private float totalTime = 40.0f; //seconds
    private float callsPerSecond = 10.0f;
    private float currentPercentage = 0.0f;
    private float size = 0.0f;

    private bool isOpen = false;

    void Start()
    {
        GetComponent<Renderer>().material = substanceFluid.material;
        goalPercentage = substanceFluid.percentage;
    }

    public void interactTube()
    {
        if(!isOpen)
        {
            openTube();
        }
        else
        {
            closeTube();
        }

    }

    void openTube()
    {
        isOpen = true;
        InvokeRepeating("Scale", 0.0f, 0.02f);

        InvokeRepeating("IncreaseFluidAmount", 0.0f, (1 / callsPerSecond));
    }

    void closeTube()
    {
        isOpen = false;
        CancelInvoke("IncreaseFluidAmount");
        InvokeRepeating("Scale", 0.0f, 0.02f);
        Debug.Log("Closed with current Percentage: " + FluidCompositionManager.GetCurrentTankVolume());
    }

    void Scale()
    {
        int blendShapeIndex;
        float blendShapeWeight;

        if (isOpen)
        {
            blendShapeIndex = 0;
        }
        else
        {
            blendShapeIndex = 1;
        }

        blendShapeWeight = GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(blendShapeIndex);

        if (blendShapeWeight > 100.0f)
        {
            CancelInvoke("Scale");
            size = 0;
            if(!isOpen)
            {
                GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0);
                GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1, 0);
            }
        }
        else
        {
            GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(blendShapeIndex, size++);
            Debug.Log("Blend Shape Index: " + blendShapeIndex + ", Weight: " + blendShapeWeight);
        }

        
    }

    //später nochmal verbessern!!
    void IncreaseFluidAmount()
    {
        bool tankIsFull;

        currentPercentage = (100.0f / (callsPerSecond*totalTime));
        tankIsFull = FluidCompositionManager.AddFluid(substanceFluid.name, currentPercentage);

        if(tankIsFull)
        {
            CancelInvoke("IncreaseFluidAmount");
        }

    }

    void IncreaseFluidAmount2()
    {
        DateTime before = DateTime.Now;

        while (currentPercentage <= goalPercentage)
        {
            currentPercentage += (100.0f / totalTime) * Time.deltaTime;
            Debug.Log("CurrentPercentage: " + currentPercentage);
        }

        DateTime after = DateTime.Now;
        TimeSpan duration = after.Subtract(before);
        Debug.Log("Fluid increase finished. Duration in milliseconds: " + duration.Seconds);

        Debug.Log("Fluid increase finished");
    }


}
