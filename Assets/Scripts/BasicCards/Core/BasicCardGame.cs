using System.Collections.Generic;

namespace BasicCards
{
    public class Deck : IDeckState<Card>
    {
        public List<Card> OrderedDeck { get; } = new List<Card>();

        public Deck()
        {
            foreach (Card.ESuit suit in System.Enum.GetValues(typeof(Card.ESuit)))
            {
                foreach (Card.EValue value in System.Enum.GetValues(typeof(Card.EValue)))
                {
                    if (value != Card.EValue.Joker)
                    {
                        OrderedDeck.Add(new Card(value, suit));
                    }
                }
            }
        }
    }

    public class PlayerBase : IPlayerState<Card>
    {
        public Hand<Card> Hand { get; } = new Hand<Card>();
    }

    public class BoardState : IBoardState
    {
        public Deck Deck;
    }

    public class BasicCardGame : IGameState<Card, PlayerBase, BoardState>
    {
        Deck m_Deck = new Deck();

        public PlayerBase UserPlayer { get; private set; }

        public PlayerBase[] AllPlayers { get; private set; }

        public PlayerBase CurrentTurnPlayer => AllPlayers[m_CurrentPlayerIndex];

        public BoardState BoardState { get; }

        public Deck Deck => m_Deck;

        int m_CurrentPlayerIndex = 0;

        public BasicCardGame(int numPlayers)
        {
            CardGameUtils.Shuffle(m_Deck);

            AllPlayers = new PlayerBase[numPlayers];
            for(int i=0;i<numPlayers;i++)
            {
                AllPlayers[i] = new PlayerBase();
            }
            UserPlayer = AllPlayers[0];

            BoardState = new BoardState()
            {
                Deck = m_Deck
            };
        }
    }
}