using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UI_Scanner : MonoBehaviour
{
   
    public TMP_Text MachineScreenText;
    public KeypadManager KeypadManager;
    public FluidCompositionManager FluidCompositionManager;
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
        KeypadManager.SubscribeCardInvalid(OnCardInvalid);

        FluidCompositionManager.SubscribeFluidAmountChanged(OnFluidAmountChanged);
        FluidCompositionManager.SubscribeCompositionCorrectEvent(OnCompositionCorrect);
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
            MachineScreenText.text = "Automatisches Befüllen fehlgeschlagen. Befüllen Sie den Tank manuell.";
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

    void OnFluidAmountChanged(float percentage)
    {
        MachineScreenText.text = "Derzeitiger Stand: " + percentage + "%.";
    }

    void OnCompositionCorrect(bool isCorrect)
    {
        if(isCorrect)
        {
            MachineScreenText.text = "Substanz erfolgreich hergestellt. Hebel betätigen zum Auswurf.";
        }
    }

    void OnCardInvalid()
    {
        MachineScreenText.text = "Diese Karte ist ungültig.";
    }
}
