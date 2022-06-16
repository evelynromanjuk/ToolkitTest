using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UI_Scanner : MonoBehaviour
{
   
    public TMP_Text MachineScreenText;
    public KeypadManager KeypadManager;
    private string ScreenTextName = " ";
    private string ScreenTextPassword = " ";

    // Start is called before the first frame update
    void Start()
    {
        Scanner ScannerObject = GameObjectLocator.ScannerObject;
        ScannerObject.Subscribe(OnScan);

        KeypadManager.SubscribePasswordEntered(OnNumberEntered);
        KeypadManager.SubscribePasswordCorrect(OnPasswordChecked);
        KeypadManager.SubscribePasswordReset(OnPasswordReset);
    }

    void OnScan(EmployeeCard card)
    {
        ScreenTextName = card.EmployeeName;
        UpdateScreen();
    }

    void OnNumberEntered(int number)
    {
        ScreenTextPassword = number.ToString();
        UpdateScreen();
    }


    void OnPasswordChecked(bool isCorrect)
    {
        if(isCorrect)
            MachineScreenText.text = "Willkommen im Bubblegum-o-mat!";
        else
        {
            ScreenTextPassword = " ";
            UpdateScreen();
        }
    }

    void OnPasswordReset()
    {
            ScreenTextPassword = " ";
            UpdateScreen();
    }

    void UpdateScreen()
    {
        MachineScreenText.text = "Name : " + ScreenTextName + " Passwort: " + ScreenTextPassword;
    }
}
