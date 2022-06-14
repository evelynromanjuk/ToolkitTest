using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    public bool isOpen = false;

    public void SetActive()
    {
        if (!isOpen)
        {
            myDoor.Play("Open", 0, 0.0f);
            isOpen = true;
        }
        //else
        //{
        //    myDoor.Play("Close", 0, 0.0f);
        //    isOpen = false;
        //    Debug.Log("Close Animation");
        //}

        Debug.Log("You Clicked");
    }

}
