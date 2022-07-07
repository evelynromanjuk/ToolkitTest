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
        EmployeeCard card = collision.gameObject.GetComponent<EmployeeCard>();
        if(card == null)
        {
            return;
        }

        ObjectScannedEvent.Invoke(card);

    }
}
