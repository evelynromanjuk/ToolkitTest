using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanObserver : MonoBehaviour
{
    public Scanner ScannerObject;
    // Start is called before the first frame update
    void Start()
    {
        ScannerObject.Subscribe(OnScan);
    }

    private void OnScan(EmployeeCard card)
    {
        Debug.Log($"Play Sound! scan detected: {card.EmployeeName}. Is valid: {card.IsValid}");
    }
}
