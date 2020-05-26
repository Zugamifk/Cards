using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleGround
{
    public class GameController : MonoBehaviour
    {

        const int k_StartHandSize = 5;
        const int k_DeckSize = 75;

        [SerializeField]
        CardDatabase m_CardDatabase;

        [SerializeField]
        HandGui m_HandGui;

        List<CardData> m_Hand = new List<CardData>();
        Deck m_Deck = new Deck();

        private void Start()
        {
            BuildDeck();
            StartGame();
        }

        void BuildDeck()
        {
            for (int i = 0; i < k_DeckSize; i++)
            {
                m_Deck.Cards.Enqueue(m_CardDatabase.Cards[0]);
            }
        }

        void StartGame()
        {
            for (int i = 0; i < k_StartHandSize; i++)
            {
                var card = m_Deck.Draw();
                m_Hand.Add(card);
                //m_HandGui.AddCard(card);
            }
        }
    }
}
