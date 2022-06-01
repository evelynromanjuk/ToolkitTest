using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_Scanner : MonoBehaviour
{
    public Text EmployeeText;
    public Text StatusText;
    public GameObject floppa;
    
    // Start is called before the first frame update
    void Start()
    {
        EmployeeText.text = "None";
        StatusText.text = "None";

        Scanner ScannerObject = GameObjectLocator.ScannerObject;
        ScannerObject.Subscribe(OnScan);
    }

    void OnScan(EmployeeCard card)
    {
        EmployeeText.text = card.EmployeeName;
        StatusText.text = card.IsValid? "Is valid":"Is not valid";
        floppa.SetActive(true);
    }
}
