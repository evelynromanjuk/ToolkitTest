using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordDoor : MonoBehaviour
{
    //private XRSimpleInteractable simpleInteractable = null;
    [SerializeField] private Animator interactableObject = null;
    [SerializeField] private KeypadManager KeypadManager;


    private void Start()
    {
        KeypadManager.SubscribeDoorPasswordCorrect(SetActive);
    }

    public void SetActive(bool passwordCorrect)
    {
        if (passwordCorrect)
        {
            interactableObject.Play("Open", 0, 0.0f);
        }

    }
}
