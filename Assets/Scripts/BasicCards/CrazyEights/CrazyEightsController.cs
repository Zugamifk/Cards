using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasicCards;

public class CrazyEightsController : MonoBehaviour
{
    [SerializeField]
    RectTransform m_BoardRoot;
    [SerializeField]
    Transform m_DeckRoot;
    [SerializeField]
    Transform m_DiscardPileRoot;

    UIService m_Ui;
    CrazyEights m_Game;

    private void Awake()
    {
        m_Game = new CrazyEights();
    }

    private void Start()
    {
        m_Ui = ServiceLocator.Get<UIService>();

        m_Ui.SetBoard(m_BoardRoot);

        Instantiate(m_Ui.DeckPrefab, m_DeckRoot);
        Instantiate(m_Ui.DiscardPilePrefab, m_DiscardPileRoot);

        m_Game.StartGame();
        for (int i = 0; i < 8; i++)
        {
            m_Ui.HandGui.AddCard(m_Game.CardGame.UserPlayer.Hand.HeldCards[i]);
        }
    }
}
