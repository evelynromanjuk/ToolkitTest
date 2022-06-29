using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckSocket : MonoBehaviour
{
    public GameObject analyzerPart;
    private XRSocketInteractor socket;

    Action<bool> PartInsertedEvent;

    // Start is called before the first frame update
    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    public void SubscribePartInsertedEvent(Action<bool> method)
    {
        PartInsertedEvent += method;
    }

    public void checkPart()
    {
        bool partIsCorrect = false;

        IXRSelectInteractable insertedPart = socket.GetOldestInteractableSelected();

        if (analyzerPart.transform.name == insertedPart.transform.name)
        {
            partIsCorrect = true;
            Debug.Log("This is the correct part");
        }
        else
        {
            Debug.Log("This is NOT the correct part");
        }



    }
}
