using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDeckState
{
    List<ICardState> OrderedDeck { get; }

}
