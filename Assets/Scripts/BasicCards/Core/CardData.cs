using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasicCards
{
    public class CardData : ICardData, ICardState
    {
        public enum ESuit
        {
            Hearts,
            Spades,
            Diamonds,
            Clubs
        }

        public enum EValue
        {
            Ace,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eights,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Joker
        }

        public ESuit Suit { get; }
        public EValue Value { get; }

        public string Name { get; }

        public ICardData Data => this;

        public IPlayerState Owner { get; set; }
        public IPlayerState Controller { get; set; }

        public CardData(EValue value, ESuit suit)
        {
            Suit = suit;
            Value = value;

            Name = $"{value} of {Suit}";
        }
    }
}
