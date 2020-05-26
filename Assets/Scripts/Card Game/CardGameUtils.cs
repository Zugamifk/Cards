using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardGameUtils
{
    public static void Shuffle(IDeckState deck)
    {
        if (deck.OrderedDeck.Count < 2) return;

        for (int i = 1; i < deck.OrderedDeck.Count; i++)
        {
            var a = deck.OrderedDeck[i];
            var j = Random.Range(0, i);
            var b = deck.OrderedDeck[j];
            deck.OrderedDeck[i] = b;
            deck.OrderedDeck[j] = a;
        }
    }

    public static ICardState DrawCard(IDeckState deck)
    {
        if (deck.OrderedDeck.Count > 0)
        {
            var card = deck.OrderedDeck[0];
            deck.OrderedDeck.RemoveAt(0);
            return card;
        } else
        {
            return null;
        }
    }

    public static IEnumerable<ICardState> DrawCards(IDeckState deck, int numberToDraw)
    {
        for(int i=0;i<numberToDraw;i++)
        {
            var card = DrawCard(deck);
            if(card!=null)
            {
                yield return card;
            } else
            {
                yield break;
            }
        }
    }
}
