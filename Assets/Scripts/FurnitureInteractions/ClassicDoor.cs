using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClassicDoor : MonoBehaviour
{
    //private XRSimpleInteractable simpleInteractable = null;
    [SerializeField] private Animator myDoor = null;
    private bool isOpen = false;

    private void Awake()
    {
        //simpleInteractable = GetComponent <XRSimpleInteractable>();

        //simpleInteractable.activated.AddListener(MoveDoor);
    }

    public void SetActive (bool value)
    {
        if (value)
        {
            myDoor.Play("DoorOpen", 0, 0.0f);
            Debug.Log("Door Open");
        }
        else
        {
            myDoor.Play("DoorClose", 0, 0.0f);
            Debug.Log("Door Closed");
        }

        Debug.Log("You Clicked");
    }

    public void SetActive2()
    {
        if (!isOpen)
        {
            myDoor.Play("DoorOpen", 0, 0.0f);
            isOpen = true;
        }
        else
        {
            myDoor.Play("DoorClose", 0, 0.0f);
            isOpen = false;
            Debug.Log("Close Animation");
        }

        Debug.Log("You Clicked");
    }
}