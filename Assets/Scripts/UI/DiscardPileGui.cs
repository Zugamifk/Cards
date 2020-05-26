using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiscardPileGui : MonoBehaviour, IDropHandler
{
    public CardGui CardGui;

    public event System.Action<GameObject> OnDropItem;
    public void OnDrop(PointerEventData eventData)
    {
        OnDropItem?.Invoke(eventData.pointerDrag);
    }
}
