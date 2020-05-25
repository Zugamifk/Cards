using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    IDeckState Deck { get; }
    IHandState Hand { get; }
    IDiscardPileState DiscardPile { get; }

    IEnumerable<ICardData> PlayedCards { get; }
}
