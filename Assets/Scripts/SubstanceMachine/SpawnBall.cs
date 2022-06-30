using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform parent;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void spawnBall()
    {
        GameObject b = Instantiate(ballPrefab);
        b.transform.SetParent(parent, false);
        b.transform.localPosition = new Vector3(-0.7f, 1.5f, 0);

        Debug.Log("Spawn Ball");
    }

    public void spawnBall2()
    {
        GameObject b = Instantiate(ballPrefab);
        b.transform.SetParent(parent, false);
        b.transform.localPosition = new Vector3(0,0,0);

        Debug.Log("Spawn Ball");
    }
}
