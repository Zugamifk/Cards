using System.Collections;
using System.Collections.Generic;

namespace BasicCards
{
    public class CrazyEights
    {
        BasicCardGame m_CardGame = new BasicCardGame(2);
        public BasicCardGame CardGame => m_CardGame;

        Stack<ICardState> m_DiscardPile = new Stack<ICardState>();

        public ICardState LastPlayedCard => m_DiscardPile.Peek();
        public int CardCount => m_CardGame.Deck.OrderedDeck.Count;

        public void StartGame()
        {
            for (int i = 0; i < m_CardGame.AllPlayers.Length; i++) {
                var startingHand = CardGameUtils.DrawCards(m_CardGame.Deck, 8);
                m_CardGame.AllPlayers[i].Hand.HeldCards.AddRange(startingHand);
            }
        }
    }
}
