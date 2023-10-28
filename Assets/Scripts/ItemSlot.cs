using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public List<DragDrop> dragDropItems = new List<DragDrop>();

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
   
    }
    private void Start()
    {
       
    }
    private void Update()
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        foreach (DragDrop dragDrop in dragDropItems)
        {
            if (dragDrop.isDropped)
            {
                return;
            }
        }
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        foreach (DragDrop dragDrop in dragDropItems)
        {
            if (dragDrop.isDropped)
            {
                return;
            }
        }
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        foreach (DragDrop dragDrop in dragDropItems)
        {
            if (dragDrop.isDropped)
            {
                return;
            }
        }
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
    public void OnDrop(PointerEventData eventData)
    {
        DragDrop droppedDragDrop = eventData.pointerDrag.GetComponent<DragDrop>();

        if (droppedDragDrop != null)
        {
            // Set isDropped to true for the specific DragDrop script.
            droppedDragDrop.isDropped = true;

            Debug.Log("OnDrop");
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }

}
