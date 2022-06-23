using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidFlow : MonoBehaviour
{

    private float size = 0.0f;

    public void openTube()
    {
        InvokeRepeating("Scale", 0.0f, 0.02f);
    }

    void Scale()
    {
        if (size >= 100.0f)
        {
            CancelInvoke("Scale");
        }

        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, size++);
    }
}
