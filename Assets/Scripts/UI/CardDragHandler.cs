using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform DropParent { get; set; }

    private Vector2 lastMousePosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastMousePosition = eventData.position;
        DropParent = transform.parent;
        transform.SetParent(DropParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        var card = GetComponent<CardGui>().Card;
        ServiceLocator.Get<GameEventService>().DraggedCard(card);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(DropParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
