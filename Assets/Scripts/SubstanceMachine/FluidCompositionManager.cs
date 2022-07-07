using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidCompositionManager : MonoBehaviour
{
    List<SubstanceFluid> fluids = new List<SubstanceFluid>();
    Action<float> FluidAmountChangedEvent;
    Action<bool> TankFilledEvent;
    Action<bool> CompositionCorrectEvent;

    private float totalPercentage = 0;

    void Start()
    {

    }

    public void SubscribeFluidAmountChanged(Action<float> method)
    {
        FluidAmountChangedEvent += method;
    }

    public void SubscribeTankFilledEvent(Action<bool> method)
    {
        TankFilledEvent += method;
    }

    public void SubscribeCompositionCorrectEvent(Action<bool> method)
    {
        CompositionCorrectEvent += method;
    }

    private void CheckComposition()
    {
        bool compositionCorrect = false;

        foreach(SubstanceFluid entry in fluids)
        {
            if(entry.reachedGoal == false)
            {
                compositionCorrect = false;
                break;
            }
            else
            {
                compositionCorrect = true;
            }
        }
        CompositionCorrectEvent.Invoke(compositionCorrect);

    }

    public bool AddFluid(SubstanceFluid fluid, float percentage)
    {
        bool tankIsFull = false;
        string fluidName = fluid.name;

        if ((totalPercentage + percentage) <= 100) //100 % 
        {

            fluid.currentPercentage += percentage;

            totalPercentage += percentage;
            FluidAmountChangedEvent.Invoke(totalPercentage);

            Debug.Log("FCM: Fluid percentage updated. Name: " + fluid.name + ", " + fluid.currentPercentage + "%");

            if (fluid.currentPercentage == fluid.percentageGoal)
            {
                Debug.Log("Percentage goal reached.");
                fluid.reachedGoal = true;
                CheckComposition();
            }
        }
        else
        {
            Debug.Log("FCM: Tank is full! Total Percentage: " + totalPercentage);
            tankIsFull = true;
        }
        return tankIsFull;
    }

    public float GetCurrentTankVolume()
    {
        return totalPercentage;
    }

    public void addFluidToList(SubstanceFluid fluid)
    {
        fluids.Add(fluid);
    }

}
