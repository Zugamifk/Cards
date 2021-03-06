﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardDropHandler : MonoBehaviour, IDropHandler
{
    public event System.Action<GameObject> OnDropItem;

    public void OnDrop(PointerEventData eventData)
    {
        OnDropItem?.Invoke(eventData.pointerDrag);
    }
}
