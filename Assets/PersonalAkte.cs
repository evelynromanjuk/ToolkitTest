using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PersonalAkte : MonoBehaviour
{
    public PersonalScriptableObject person;
    public TMP_Text textfenster;


    private void Awake()
    {
        GetComponentInChildren<TMP_Text>().text = person.Name;
    }

    public void OnClick()
    {
        textfenster.text = person.text;
    }
}
