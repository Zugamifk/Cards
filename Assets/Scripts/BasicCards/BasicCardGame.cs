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
                    OrderedDeck.Add(new CardData(value, suit));
                }
            }
        }

        public void Shuffle()
        {
            for(int i=1;i<OrderedDeck.Count;i++)
            {
                var a = OrderedDeck[i];
                var j = UnityEngine.Random.Range(0, i);
                var b = OrderedDeck[j];
                OrderedDeck[i] = b;
                OrderedDeck[j] = a;
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
        public IDeckState Deck => throw new System.NotImplementedException();

        public IHandState Hand => throw new System.NotImplementedException();

        public IDiscardPileState DiscardPile => throw new System.NotImplementedException();

        public IEnumerable<ICardData> PlayedCards => throw new System.NotImplementedException();
    }

    public class BoardState : IBoardState
    {
        public Deck Deck;
        public Stack<CardData> PlayedCards = new Stack<CardData>();
    }

    public class CardGameBase : IGameState
    {
        public IPlayerState UserPlayer { get; private set; }

        public IPlayerState[] AllPlayers { get; private set; }

        public IPlayerState CurrentTurnPlayer => AllPlayers[m_CurrentPlayerIndex];

        public IBoardState BoardState { get; }

        int m_CurrentPlayerIndex = 0;

        public CardGameBase()
        {
            BoardState = new BoardState()
            {
                Deck = new Deck()
            };
        }

        public void Start()
        {
            AllPlayers = new 
        }
    }
}