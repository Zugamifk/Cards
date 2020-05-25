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
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Vector2 currentMousePosition = eventData.position;
        //Vector2 diff = currentMousePosition - lastMousePosition;
        //RectTransform rect = GetComponent<RectTransform>();

        //Vector3 newPosition = rect.position + new Vector3(diff.x, diff.y, transform.position.z);
        //Vector3 oldPos = rect.position;
        //rect.position = newPosition;
        //if (!IsRectTransformInsideSreen(rect))
        //{
        //    rect.position = oldPos;
        //}
        //lastMousePosition = currentMousePosition;

        transform.position = eventData.position;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        //List<GameObject> hoveredList = eventData.hovered;
        //foreach (var GO in hoveredList)
        //{
        //    Debug.Log(GO.name);
        //    var board = GO.GetComponent<BoardDropHandler>();
        //    if (board != null)
        //    {
        //        board.PlayCard(GetComponent<CardGui>());
        //        continue;
        //    }
        //}
        transform.SetParent(DropParent);
        //this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    private bool IsRectTransformInsideSreen(RectTransform rectTransform)
    {
        bool isInside = false;
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        int visibleCorners = 0;
        Rect rect = new Rect(0, 0, Screen.width, Screen.height);
        foreach (Vector3 corner in corners)
        {
            if (rect.Contains(corner))
            {
                visibleCorners++;
            }
        }
        if (visibleCorners == 4)
        {
            isInside = true;
        }
        return isInside;
    }
}
