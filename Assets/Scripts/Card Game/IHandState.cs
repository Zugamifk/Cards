using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandState
{
    List<ICardState> HeldCards { get; }
}
