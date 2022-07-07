using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OpenCloseScript : MonoBehaviour
{
    [SerializeField] private Animator interactableObject = null;

    public bool isOpen = false;


    public void SetActive()
    {
        if (!isOpen)
        {
            interactableObject.Play("Open", 0, 0.0f);
            isOpen = true;
        }
        else
        {
            interactableObject.Play("Close", 0, 0.0f);
            isOpen = false;
        }
    }
}