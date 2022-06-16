using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void spawnBall()
    {
        GameObject b = Instantiate(ballPrefab) as GameObject;
        b.transform.position = new Vector3(2.39f, 1.5f, 4.68f);

        Debug.Log("Spawn Ball");
    }
}
