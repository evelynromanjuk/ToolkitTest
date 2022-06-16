using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBackgrounds : MonoBehaviour
{
    public GameObject Background;
    public List<GameObject> backgrounds;

    public void Awake()
    {
        for (int i = 1; i < Background.transform.childCount; i++)
        {
            backgrounds.Add(Background.transform.GetChild(i).gameObject);
        }
        
    }

    public void resetBackgrounds()
    {
        foreach (GameObject background in backgrounds)
        {
            background.SetActive(false);
        }
    }
}
