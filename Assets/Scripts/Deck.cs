using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleGround
{
    public class Deck
    {
        public Queue<CardData> Cards = new Queue<CardData>();

        public CardData Draw()
        {
            return Cards.Dequeue();
        }
    }
}