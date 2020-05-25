using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICardState
{
    ICardData Data { get; }
    IPlayerState Owner { get; set; }
    IPlayerState Controller { get; set; }
}
