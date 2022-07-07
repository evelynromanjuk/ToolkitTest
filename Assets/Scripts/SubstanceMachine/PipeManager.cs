using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PipeManager : MonoBehaviour
{
    public SubstanceFluid substanceFluid;
    public FluidCompositionManager FluidCompositionManager;
    public KeypadManager KeypadManager;

    private float percentageGoal;
    private float currentPercentage = 0.0f;
    private float size = 0.0f;

    private bool isOpen = false;

    private XRSimpleInteractable simpleInteractable = null;
    public GameObject Valve;


    private void Awake()
    {
        substanceFluid.currentPercentage = 0;
        substanceFluid.reachedGoal = false;
        FluidCompositionManager.addFluidToList(substanceFluid);

        simpleInteractable = Valve.GetComponent<XRSimpleInteractable>();
        simpleInteractable.enabled = false;

        KeypadManager.SubscribePasswordCorrect(OnPasswordChecked);
    }
    void Start()
    {
        GetComponent<Renderer>().material = substanceFluid.material;
        percentageGoal = substanceFluid.percentageGoal;
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

        InvokeRepeating("IncreaseFluidAmount", 0.0f, (1));
    }

    void closeTube()
    {
        isOpen = false;
        CancelInvoke("IncreaseFluidAmount");
        InvokeRepeating("Scale", 0.0f, 0.02f);
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
        }

        
    }

    void IncreaseFluidAmount()
    {
        bool tankIsFull;

        currentPercentage = 1;
        tankIsFull = FluidCompositionManager.AddFluid(substanceFluid, currentPercentage);

        if (tankIsFull)
        {
            CancelInvoke("IncreaseFluidAmount");
        }

    }

    void OnPasswordChecked(bool isCorrect)
    {
        if(isCorrect)
        {
            simpleInteractable.enabled = true;
        }
        else
        {
            simpleInteractable.enabled = false;
        }
    }


}
