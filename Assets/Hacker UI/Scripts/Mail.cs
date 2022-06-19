using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mail : MonoBehaviour
{
    public MailScriptableObject baseMail;
    public GameObject mailTextPanel;
    public bool viewed = false;
    public void ShowMail()
    {
        mailTextPanel.transform.Find("Absender").GetComponent<TMP_Text>().text = baseMail.Absender;
        mailTextPanel.transform.Find("Betreff").GetComponent<TMP_Text>().text = baseMail.Betreff;
        mailTextPanel.transform.Find("Text").GetComponent<TMP_Text>().text = baseMail.Text;
        viewed = true;

        transform.Find("Viewed").gameObject.SetActive(false);
        transform.Find("Betreff").GetComponent<TMP_Text>().color = Color.black;
    }
}
