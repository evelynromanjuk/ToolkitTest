using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCard : MonoBehaviour
{
    public AnalyzerManager analyzerManager;
    public GameObject dropzone;
    public GameObject card;

    private void Start()
    {
        analyzerManager.SubscribeSubstanceAnalyzedEvent(spawnCard);
    }
    public void spawnCard()
    {
        dropzone.SetActive(true);
        card.SetActive(true);

        Debug.Log("Spawn Card");
    }

}
