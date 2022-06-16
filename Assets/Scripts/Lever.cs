using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Lever : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private KeypadManager KeypadManager;

    private XRSimpleInteractable simpleInteractable = null;

    public bool isOpen = false;

    private void Awake()
    {
        simpleInteractable = gameObject.GetComponent<XRSimpleInteractable>();
        simpleInteractable.enabled = false;
    }

    void Start()
    {
        KeypadManager.SubscribePasswordCorrect(OnPasswordCorrect);
    }

    private void OnPasswordCorrect(bool isCorrect)
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
        //else
        //{
        //    myDoor.Play("Close", 0, 0.0f);
        //    isOpen = false;
        //    Debug.Log("Close Animation");
        //}

        Debug.Log("You Clicked");
    }

}
