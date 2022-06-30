using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCard : MonoBehaviour
{
    //public GameObject cardPrefab;
    //public Transform parent;

    public AnalyzerManager analyzerManager;
    public GameObject dropzone;
    public GameObject card;

    private void Start()
    {
        analyzerManager.SubscribeSubstanceAnalyzedEvent(spawnCard);
    }
    public void spawnCard()
    {
        //GameObject b = Instantiate(cardPrefab);
        //b.transform.SetParent(parent, false);
        //b.transform.localPosition = new Vector3(0.562f, 0.97f, 3.9f);

        dropzone.SetActive(true);
        card.SetActive(true);

        Debug.Log("Spawn Card");
    }

}
