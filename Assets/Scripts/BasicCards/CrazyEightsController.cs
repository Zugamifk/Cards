using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasicCards;

public class CrazyEightsController : MonoBehaviour
{
    [SerializeField]
    HandGui m_HandGui;

    CrazyEights m_Game;

    private void Awake()
    {
        m_Game = new CrazyEights();
    }

    private void Start()
    {
        m_Game.StartGame();
        for (int i = 0; i < 8; i++)
        {
            m_HandGui.AddCard(m_Game.CardGame.UserPlayer.Hand.HeldCards[i]);
        }
    }
}
