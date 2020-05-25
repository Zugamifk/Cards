using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardDropHandler : MonoBehaviour, IDropHandler
{
    [SerializeField]
    Transform m_PlayedCards;

    public void OnDrop(PointerEventData eventData)
    {
        var dropped = eventData.pointerDrag.GetComponent<CardDragHandler>();
        if (dropped != null)
        {
            dropped.DropParent = transform;
        }
    }

    public void PlayCard(CardGui card)
    {
        card.transform.SetParent(m_PlayedCards, false);
    }
}
