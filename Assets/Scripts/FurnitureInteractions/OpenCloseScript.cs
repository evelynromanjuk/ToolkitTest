using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OpenCloseScript : MonoBehaviour
{
    //private XRSimpleInteractable simpleInteractable = null;
    [SerializeField] private Animator myDoor = null;

    public bool isOpen = false;

    private void Awake()
    {
        //simpleInteractable = GetComponent <XRSimpleInteractable>();

        //simpleInteractable.activated.AddListener(MoveDoor);

    }

    public void SetActive()
    {
        if (!isOpen)
        {
            myDoor.Play("Open", 0, 0.0f);
            isOpen = true;
        }
        else
        {
            myDoor.Play("Close", 0, 0.0f);
            isOpen = false;
            Debug.Log("Close Animation");
        }

        Debug.Log("You Clicked");
    }
}