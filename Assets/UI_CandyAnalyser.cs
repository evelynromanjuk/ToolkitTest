using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CandyAnalyser : MonoBehaviour
{

    public Image[] boxes;
    [SerializeField]
    public AnalyzerManager analyzerManager;

    private void Awake()
    {
        boxes = GetComponentsInChildren<Image>();
        analyzerManager.SubscribeSocketsCheckedEvent(checkSockets);
        foreach(Image box in boxes)
        {
            box.color = new Vector4(1, 0, 0, 0.5f);
        }
    }

    public void checkSockets(Dictionary<int, bool> sockets)
    {
        for (int i = 1; i <= 5; i++)
        {
            sockets.TryGetValue(i, out bool fits);
            if (fits)
            {
                boxes[i - 1].color = new Vector4(0, 1, 0, 0.5f);
                
            } else boxes[i - 1].color = new Vector4(1, 0, 0, 0.5f);
        }
    }
}
