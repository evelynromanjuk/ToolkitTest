using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeypadManager : MonoBehaviour
{
    private int enteredValue = 0;
    private int employeePassword = 0;

    private string doorPassword = "LOLLIPOP";
    private string enteredPassword = "";

    public Scanner Scanner;

    Action<int> PasswordEnteredEvent;
    Action<bool> PasswordCorrectEvent;
    Action<bool> DoorPasswordCorrectEvent;
    Action PasswordResetEvent;

    void Start()
    {
        Scanner.Subscribe(SaveEmployeePassword);
    }

    public void SubscribePasswordEntered(Action<int> method)
    {
        PasswordEnteredEvent += method;
    }

    public void SubscribePasswordCorrect(Action<bool> method)
    {
        PasswordCorrectEvent += method;
    }

    public void SubscribePasswordReset(Action method)
    {
        PasswordResetEvent += method;
    }

    public void SubscribeDoorPasswordCorrect(Action<bool> method)
    {
        DoorPasswordCorrectEvent += method;
    }


    public void UpdateValue(int number)
    {
        enteredValue = enteredValue * 10 + number;
        Debug.Log("KeypadManager: Current Value: " + enteredValue);

        PasswordEnteredEvent.Invoke(enteredValue);
    }

    private void SaveEmployeePassword(EmployeeCard card)
    {
        employeePassword = card.Password;
        Debug.Log("Saved Password as: " + employeePassword);
    }

    public void CheckCandyPassword()
    {
        bool isCorrect = false;

        if (employeePassword == enteredValue)
        {
            Debug.Log("THIS IS CORRECT");
            isCorrect = true;
        }
        else
        {

            Debug.Log("THIS IS NOT CORRECT! Employee Password: " + employeePassword + ", enteredValue: " + enteredValue);
            enteredValue = 0;
        }

        PasswordCorrectEvent.Invoke(isCorrect);
    }

    public void ResetCandyPassword()
    {
        enteredValue = 0;
        PasswordResetEvent.Invoke();

    }

    public void EnterDoorPassword(string letter)
    {
        enteredPassword = enteredPassword + letter;
        Debug.Log("KeypadManager: Entered Password: " + enteredPassword);
    }

    public void CheckDoorPassword()
    {
        bool isCorrect = false;

        if(doorPassword == enteredPassword)
        {
            Debug.Log("PASSWORD CORRECT");
            isCorrect = true;
        }
        else
        {
            Debug.Log("PASSWORD IS NOT CORRECT");
            enteredPassword = "";
        }

        DoorPasswordCorrectEvent.Invoke(isCorrect);
    }
   


    public void ResetDoorPassword()
    {
        enteredPassword = "";
    }
}
