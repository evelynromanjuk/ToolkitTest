using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWindow : MonoBehaviour
{
    public void EnableWindow(GameObject window)
    {
        window.SetActive(true);
    }

    public void DisableWindow(GameObject window)
    {
        window.SetActive(false);
    }
}
