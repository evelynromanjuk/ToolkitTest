using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyzerManager : MonoBehaviour
{
    [SerializeField] private CheckSocket socketChip;
    [SerializeField] private CheckSocket socketKabel1;
    [SerializeField] private CheckSocket socketKabel2;
    [SerializeField] private CheckSocket socketZahnrad;
    [SerializeField] private CheckSocket socketKolben;

    Dictionary<int, bool> sockets;

    Action<Dictionary<int, bool>> SocketsCheckedEvent;
    Action SubstanceAnalyzedEvent;

    private bool allCorrect;
    private bool substanceBallInserted;

    void Start()
    {
        allCorrect = false;
        substanceBallInserted = false;

        sockets = new Dictionary<int, bool>();
        sockets.Add(1, false);
        sockets.Add(2, false);
        sockets.Add(3, false);
        sockets.Add(4, false);
        sockets.Add(5, false);

        socketChip.SubscribePartInsertedEvent(LogInsertedPart);
        socketKabel1.SubscribePartInsertedEvent(LogInsertedPart);
        socketKabel2.SubscribePartInsertedEvent(LogInsertedPart);
        socketZahnrad.SubscribePartInsertedEvent(LogInsertedPart);
        socketKolben.SubscribePartInsertedEvent(LogInsertedPart);

    }

    public void SubscribeSubstanceAnalyzedEvent(Action method)
    {
        SubstanceAnalyzedEvent += method;
    }

    public void SubscribeSocketsCheckedEvent(Action<Dictionary<int, bool>> method)
    {
        SocketsCheckedEvent += method;
    }

    void LogInsertedPart(int socketId, bool partIsCorrect)
    {
        if(partIsCorrect)
        {
            sockets[socketId] = true;
        }
        else
        {
            sockets[socketId] = false;
        }

        CheckAllSockets();
    }

    void CheckAllSockets()
    {
        foreach(KeyValuePair<int, bool> entry in sockets)
        {
            if (entry.Value == false)
            {
                allCorrect = false;
                break;
            }
            else
            {
                allCorrect = true;
            }
        }
    }

    public void InsertSubstanceBall()
    {
        substanceBallInserted = true;
        Debug.Log("Ball inserted.");

    }

    public void StartAnalyzer()
    {
        if(allCorrect & substanceBallInserted)
        {
            Debug.Log("Level completed.");
            SubstanceAnalyzedEvent.Invoke();
        }
        else
        {
            Debug.Log("Failed: Substance Ball inserted = " + substanceBallInserted + ", all parts correct= " + allCorrect);

        }
    }

    public void CheckSockets()
    {
        foreach(KeyValuePair<int, bool> entry in sockets)
        {
            Debug.Log("Socket #" + entry.Key + ": " + entry.Value);
        }

        SocketsCheckedEvent.Invoke(sockets);
    }

}
