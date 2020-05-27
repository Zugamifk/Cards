using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasicCards;

public class CrazyEightsController : MonoBehaviour
{
    [SerializeField]
    RectTransform m_BoardRoot;
    [SerializeField]
    DeckGui m_Deck;
    [SerializeField]
    DiscardPileGui m_DiscardPile;

    UIService m_Ui;
    CrazyEights m_Game;

    CardGui m_DiscardPileTopCard;

    private void Awake()
    {
        m_Game = new CrazyEights();
    }

    private void Start()
    {
        m_Ui = ServiceLocator.Get<UIService>();

        m_Ui.SetBoard(m_BoardRoot);
        m_Ui.OnPlayedCard += PlayCard;

        m_DiscardPile.OnDropItem += PlayCard;
        m_Deck.OnClicked += DrawCard;

        m_Game.StartGame();
        for (int i = 0; i < 8; i++)
        {
            m_Ui.HandGui.AddCard(m_Game.CardGame.UserPlayer.Hand.HeldCards[i]);
        }
    }

    void PlayCard(GameObject cardGo)
    {
        var cardGui = cardGo.GetComponent<CardGui>();
        var card = (Card)cardGui.Card;
        if (IsPlayable(card)) {
            m_Game.PlayCard(card);
            m_DiscardPile.CardGui.SetCard(cardGui.Card);
            Destroy(cardGo);
        }
    }

    void DrawCard()
    {
        var card = m_Game.DrawCard(m_Game.CardGame.CurrentTurnPlayer);
        m_Ui.HandGui.AddCard(card);
    }

    bool IsPlayable(Card card)
    {
        return m_Game.LastPlayedCard == null || card.Suit == m_Game.LastPlayedCard.Suit || card.Value == m_Game.LastPlayedCard.Value;
    }
}
