using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DeactiveDoor : MonoBehaviour
{

    [SerializeField] private GameObject door2 = null;
    private XRSimpleInteractable simpleInteractable = null;

    // Start is called before the first frame update
    void Awake()
    {
        simpleInteractable = door2.GetComponent<XRSimpleInteractable>();
    }

    public void deactivateDoor2()
    {
        simpleInteractable.enabled = !simpleInteractable.enabled;
    }
}
