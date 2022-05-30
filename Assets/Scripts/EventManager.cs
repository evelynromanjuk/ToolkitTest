using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action ExampleEvent;
    public static event Action ScanIDEvent;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //if(ExampleEvent != null)
            //{
            //    ExampleEvent();
            //}

            ExampleEvent?.Invoke();
        }
    }

    public static void StartScanIDEvent()
    {
        ScanIDEvent?.Invoke();
    }
}
