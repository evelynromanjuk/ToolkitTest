using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler
{
    [SerializeField] private RectTransform dragRectTransform;
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform canvasTransform;

    private void Awake()
    {
        if(!dragRectTransform)
        {
            dragRectTransform = transform.parent.GetComponent<RectTransform>();
        }

        if(!canvas)
        {
            canvas = GetComponentInParent<Canvas>();
        }

        if(!canvasTransform)
        {
            canvas.gameObject.GetComponent<RectTransform>();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
        dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragRectTransform.SetAsLastSibling();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragRectTransform.anchoredPosition.x < 0)
        {
            dragRectTransform.anchoredPosition = new Vector2(0, dragRectTransform.anchoredPosition.y);
        }
        if (dragRectTransform.anchoredPosition.x > canvasTransform.rect.width - dragRectTransform.rect.width)
        {
            dragRectTransform.anchoredPosition = new Vector2((canvasTransform.rect.width - dragRectTransform.rect.width), dragRectTransform.anchoredPosition.y);
        }
        if (dragRectTransform.anchoredPosition.y > 0)
        {
            dragRectTransform.anchoredPosition = new Vector2(dragRectTransform.anchoredPosition.x, 0);
        }
        if (dragRectTransform.anchoredPosition.y < -(canvasTransform.rect.height - dragRectTransform.rect.height))
        {
            dragRectTransform.anchoredPosition = new Vector2(dragRectTransform.anchoredPosition.x, -(canvasTransform.rect.height-dragRectTransform.rect.height));
        }
    }
}
