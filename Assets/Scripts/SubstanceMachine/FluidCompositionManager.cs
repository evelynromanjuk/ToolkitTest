using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidCompositionManager : MonoBehaviour
{

    //Dictionary<string, float> fluids = new Dictionary<string, float>();
    List<SubstanceFluid> fluids = new List<SubstanceFluid>();
    Action<float> FluidAmountChangedEvent;
    Action<bool> TankFilledEvent;
    Action<bool> CompositionCorrectEvent;

    private float totalPercentage = 0;

    // Start is called before the first frame update
    void Start()
    {
       foreach(SubstanceFluid entry in fluids)
        {
            Debug.Log(entry.name + " / Goal: " + entry.percentageGoal + " / IsReached: " + entry.reachedGoal);
        }
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
            //Debug.Log("FCM: Fluid percentage updated. Name: " + name + ", " + percentage + "%");

            totalPercentage += percentage;
            FluidAmountChangedEvent.Invoke(totalPercentage);
            //Debug.Log("FCM: Total Percentage: " + totalPercentage + "%");
            Debug.Log("FCM: Fluid percentage updated. Name: " + fluid.name + ", " + fluid.currentPercentage + "%");

            if (fluid.currentPercentage == fluid.percentageGoal)
            {
                Debug.Log("YAY you reached it!!");
                fluid.reachedGoal = true;
                CheckComposition();
            }
        }
        else
        {
            Debug.Log("FCM: Tank is full! Total Percentage: " + totalPercentage);
            tankIsFull = true;
            //TankFilledEvent.Invoke(tankIsFull);
            Debug.Log("Tank contains following fluids:");
            foreach (SubstanceFluid entry in fluids)
            {
                Debug.Log(entry.name + "/ " + entry.currentPercentage + "%");
            }
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
        Debug.Log("FCM: New fluid added!");

    }

}
