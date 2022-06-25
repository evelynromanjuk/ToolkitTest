using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidCompositionManager : MonoBehaviour
{

    //public PipeManager PipeManager;

    Dictionary<string, float> fluids = new Dictionary<string, float>();
    private float totalPercentage = 0;

    // Start is called before the first frame update
    void Start()
    {
        //PipeManager.SubscribeFluidChange(checkComposition);
    }


    private void CheckComposition(string color, int percentage)
    {

    }

    public bool AddFluid(string name, float percentage)
    {
        bool tankIsFull = false;

        if((totalPercentage + percentage) <= 20)
        {
            if (!fluids.ContainsKey(name))
            {
                fluids.Add(name, percentage);
                Debug.Log("FCM: New fluid added!");
            }
            else
            {
                fluids[name] = percentage;
                Debug.Log("FCM: Fluid percentage updated. Name: " + name + ", " + percentage + "%");

            }
            totalPercentage += percentage;
            Debug.Log("FCM: Total Percentage: " + totalPercentage + "%");
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
}
