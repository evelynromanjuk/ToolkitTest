using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UI_Scanner : MonoBehaviour
{
<<<<<<< Updated upstream
    public Text EmployeeText;
    public Text StatusText;
=======
    //private Text EmployeeText;
    //private Text StatusText;
    public TMP_Text MachineScreenText;
>>>>>>> Stashed changes
    
    // Start is called before the first frame update
    void Start()
    {
        //EmployeeText.text = "None";
        //StatusText.text = "None";

        Scanner ScannerObject = GameObjectLocator.ScannerObject;
        ScannerObject.Subscribe(OnScan);
    }

    void OnScan(EmployeeCard card)
    {
<<<<<<< Updated upstream
        EmployeeText.text = card.EmployeeName;
        StatusText.text = card.IsValid? "Is valid":"Is not valid";
=======
        //EmployeeText.text = card.EmployeeName;
        //StatusText.text = card.IsValid? "Is valid":"Is not valid";

        MachineScreenText.text = "ASDFAKDLSF";
>>>>>>> Stashed changes
    }
}
