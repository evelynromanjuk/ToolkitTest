using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    Action<EmployeeCard> ObjectScannedEvent;

    public void Subscribe(Action<EmployeeCard> method)
    {
        ObjectScannedEvent += method;
    }

    private void Awake()
    {
        GameObjectLocator.ScannerObject = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ObjectScannedEvent += CollisionDetected;
    }

    void CollisionDetected(EmployeeCard card)
    {
        Debug.Log("CollisionDetected invoked");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // test on tag if it is a scannable object
        // ... 
        EmployeeCard card = collision.gameObject.GetComponent<EmployeeCard>();
        if(card == null)
        {
            Debug.Log("object is not a card!");
            return;
        }

        ObjectScannedEvent.Invoke(card);
    }
}
