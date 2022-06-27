using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Lever : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    //[SerializeField] private KeypadManager KeypadManager;
    [SerializeField] private FluidCompositionManager FluidCompositionManager;

    private XRSimpleInteractable simpleInteractable = null;

    public bool isOpen = false;

    private void Awake()
    {
        simpleInteractable = gameObject.GetComponent<XRSimpleInteractable>();
        simpleInteractable.enabled = false;
    }

    void Start()
    {
        //KeypadManager.SubscribePasswordCorrect(OnPasswordCorrect);
        FluidCompositionManager.SubscribeCompositionCorrectEvent(OnCompositionCorrect);
    }

    private void OnCompositionCorrect(bool isCorrect)
    {
        if(isCorrect)
        {
            simpleInteractable.enabled = true;
        }
    }

    public void SetActive()
    {
        if (!isOpen)
        {
            myDoor.Play("Open", 0, 0.0f);
            isOpen = true;
            simpleInteractable.enabled = false;
        }

        Debug.Log("You Clicked");
    }

}
