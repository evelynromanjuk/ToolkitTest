using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MailManager : MonoBehaviour
{
    public GameObject MailScroll;
    public GameObject MailPrefab;
    public GameObject mailTextPanel;
    public AudioSource youveGotMail;

    private void Awake()
    {
        youveGotMail = GetComponent<AudioSource>();
    }
    public void CreateMail(MailScriptableObject mail)
    {
        GameObject Email = Instantiate(MailPrefab, MailScroll.transform);
        Email.transform.SetAsFirstSibling();
        Email.GetComponent<Mail>().baseMail = mail;
        Email.GetComponent<Mail>().mailTextPanel = mailTextPanel;
        Email.transform.Find("Betreff").GetComponent<TMP_Text>().text = mail.Betreff;
        Email.transform.Find("Absender").GetComponent<TMP_Text>().text = mail.Absender;
        youveGotMail.Play();
    }
}
