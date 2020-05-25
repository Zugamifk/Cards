using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDiscardPileState
{
    List<ICardState> Pile { get; }
}
