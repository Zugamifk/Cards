using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState<TCardState>
    where TCardState : ICardState
{
    Hand<TCardState> Hand { get; }
}
