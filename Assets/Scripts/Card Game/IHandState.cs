using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand<TCardState>
    where TCardState : ICardState
{
    public List<TCardState> HeldCards { get; } = new List<TCardState>();
}
