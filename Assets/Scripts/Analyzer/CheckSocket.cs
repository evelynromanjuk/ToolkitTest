using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckSocket : MonoBehaviour
{
    public GameObject analyzerPart;
    private XRSocketInteractor socket;
    

    Action<int, bool> PartInsertedEvent;

    // Start is called before the first frame update
    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    public void SubscribePartInsertedEvent(Action<int, bool> method)
    {
        PartInsertedEvent += method;
    }

    public void checkPart(int socketID)
    {
        bool partIsCorrect = false;

        IXRSelectInteractable insertedPart = socket.GetOldestInteractableSelected();

        if(insertedPart == null)
        {
            Debug.Log("Inserted Object is Null");
        }
        if (analyzerPart == null)
        {
            Debug.Log("Reference Object is Null");
        }

        if (analyzerPart.transform.name == insertedPart.transform.name)
        {
            partIsCorrect = true;
            Debug.Log("This is the correct part");
        }

        else
        {
            Debug.Log("This is NOT the correct part");
        }

        PartInsertedEvent.Invoke(socketID, partIsCorrect);


    }


}
