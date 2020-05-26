using System.Collections.Generic;

namespace BasicCards
{
    public class Deck : IDeckState
    {
        public List<ICardState> OrderedDeck { get; }

        public Deck()
        {
            OrderedDeck = new List<ICardState>();
            foreach (CardData.ESuit suit in System.Enum.GetValues(typeof(CardData.ESuit)))
            {
                foreach (CardData.EValue value in System.Enum.GetValues(typeof(CardData.EValue)))
                {
                    if (value != CardData.EValue.Joker)
                    {
                        OrderedDeck.Add(new CardData(value, suit));
                    }
                }
            }
        }
    }

    public class Hand : IHandState
    {
        public List<ICardState> HeldCards
        {
            get;
        }
        public Hand()
        {
            HeldCards = new List<ICardState>();
        }
    }


    public class PlayerBase : IPlayerState
    {
        public IDeckState Deck {get; set; }

        public IHandState Hand { get; } = new Hand();

        public IDiscardPileState DiscardPile { get; set; }

        public IEnumerable<ICardData> PlayedCards { get; } = new List<CardData>();
    }

    public class BoardState : IBoardState
    {
        public Deck Deck;
    }

    public class BasicCardGame : IGameState
    {
        Deck m_Deck = new Deck();

        public IPlayerState UserPlayer { get; private set; }

        public IPlayerState[] AllPlayers { get; private set; }

        public IPlayerState CurrentTurnPlayer => AllPlayers[m_CurrentPlayerIndex];

        public BoardState BoardState { get; }
        IBoardState IGameState.BoardState => BoardState;

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