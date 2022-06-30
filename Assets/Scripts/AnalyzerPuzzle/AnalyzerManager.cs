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

    private bool allCorrect;
    private bool substanceBallInserted;

    // Start is called before the first frame update
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

        socketChip.SubscribePartInsertedEvent(logInsertedPart);
        socketKabel1.SubscribePartInsertedEvent(logInsertedPart);
        socketKabel2.SubscribePartInsertedEvent(logInsertedPart);
        socketZahnrad.SubscribePartInsertedEvent(logInsertedPart);
        socketKolben.SubscribePartInsertedEvent(logInsertedPart);

    }

    public void SubscribeSocketsCheckedEvent(Action<Dictionary<int, bool>> method)
    {
        SocketsCheckedEvent += method;
    }

    void logInsertedPart(int socketId, bool partIsCorrect)
    {
        if(partIsCorrect)
        {
            sockets[socketId] = true;
        }
        else
        {
            sockets[socketId] = false;
        }

        checkAllSockets();
    }

    void checkAllSockets()
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

        if (allCorrect)
            Debug.Log("All Parts are correct!");
    }

    public void insertSubstanceBall()
    {
        substanceBallInserted = true;
        Debug.Log("Ball inserted");

    }

    public void startAnalyzer()
    {
        if(allCorrect & substanceBallInserted)
        {
            Debug.Log("CONGRATULATIONSSSS");
        }
        else
        {
            Debug.Log("Failed: Substance Ball inserted = " + substanceBallInserted + ", all parts correct= " + allCorrect);

        }
    }

    public void checkSockets()
    {
        foreach(KeyValuePair<int, bool> entry in sockets)
        {
            Debug.Log("Socket #" + entry.Key + ": " + entry.Value);
        }

        SocketsCheckedEvent.Invoke(sockets);
    }

}
