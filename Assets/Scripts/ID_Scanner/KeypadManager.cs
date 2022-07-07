using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeypadManager : MonoBehaviour
{
    private int enteredValue = 0;
    private int employeePassword = 0;

    private bool cardIsValid = false;

    private string doorPassword = "LOLLIPOP";
    private string enteredPassword = "";

    public Scanner Scanner;

    Action<int> PasswordEnteredEvent;
    Action<bool> PasswordCorrectEvent;
    Action<bool> DoorPasswordCorrectEvent;
    Action PasswordResetEvent;
    Action CardInvalidEvent;

    void Start()
    {
        Scanner.Subscribe(SaveEmployeeData);
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

    public void SubscribeCardInvalid(Action method)
    {
        CardInvalidEvent += method;
    }


    public void UpdateValue(int number)
    {
        enteredValue = enteredValue * 10 + number;
        Debug.Log("KeypadManager: Current Value: " + enteredValue);

        PasswordEnteredEvent.Invoke(enteredValue);
    }

    private void SaveEmployeeData(EmployeeCard card)
    {
        employeePassword = card.Password;
        cardIsValid = card.IsValid;
        Debug.Log("Saved Password as: " + employeePassword);
    }

    public void CheckCandyPassword()
    {
        bool isCorrect = false;

        if (employeePassword == enteredValue & cardIsValid)
        {
            isCorrect = true;
        }
        else
        {
            enteredValue = 0;
        }

        if (!cardIsValid)
        {
            CardInvalidEvent.Invoke();
        }
        else
        {
            PasswordCorrectEvent.Invoke(isCorrect);
        }
        
    }

    public void ResetCandyPassword()
    {
        enteredValue = 0;
        PasswordResetEvent.Invoke();

    }

    public void EnterDoorPassword(string letter)
    {
        enteredPassword = enteredPassword + letter;
    }

    public void CheckDoorPassword()
    {
        bool isCorrect = false;

        if(doorPassword == enteredPassword)
        {
            Debug.Log("Password correct.");
            isCorrect = true;
        }
        else
        {
            Debug.Log("Password not correct.");
            enteredPassword = "";
        }

        DoorPasswordCorrectEvent.Invoke(isCorrect);
    }
   


    public void ResetDoorPassword()
    {
        enteredPassword = "";
    }
}
