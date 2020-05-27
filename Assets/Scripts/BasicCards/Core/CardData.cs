using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasicCards
{
    public class Card : ICardState
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

        public Card(EValue value, ESuit suit)
        {
            Suit = suit;
            Value = value;

            Name = $"{value} of {Suit}";
        }
    }
}
