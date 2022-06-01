using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BringWindowToFront : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private RectTransform dragRectTransform;
    private void Awake()
    {
        if (!dragRectTransform)
        {
            dragRectTransform = transform.parent.GetComponent<RectTransform>();
        }
    }
        public void OnPointerDown(PointerEventData eventData)
    {
        dragRectTransform.SetAsLastSibling();
    }
}
