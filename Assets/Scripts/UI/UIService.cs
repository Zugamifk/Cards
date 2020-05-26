using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIService: MonoBehaviour, IService
{
    public HandGui HandGui;
    public Transform BoardRoot;
    public BoardDropHandler BoardDropHandler;

    public CardGui CardPrefab;
    public GameObject DeckPrefab;
    public DiscardPileGui DiscardPilePrefab;

    public event System.Action<GameObject> OnPlayedCard;

    void Awake()
    {
        ServiceLocator.Register(this);
        BoardDropHandler.OnDropItem += OnPlayedCard;
    }

    public void SetBoard(RectTransform rt)
    {
        rt.SetParent(BoardRoot);
        rt.anchoredPosition = Vector3.zero;
        rt.anchorMax = Vector2.one;
        rt.anchorMin = Vector2.zero;
        rt.sizeDelta = Vector2.zero;
    }
}
