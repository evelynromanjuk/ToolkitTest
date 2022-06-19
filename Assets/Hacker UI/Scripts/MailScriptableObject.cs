using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E-Mail", menuName ="Mail", order=1)]
public class MailScriptableObject : ScriptableObject
{
    public string Betreff;
    public string Absender;
    public string Text;
}
