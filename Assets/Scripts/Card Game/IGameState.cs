using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameState
{
    IPlayerState UserPlayer { get; }
    IPlayerState[] AllPlayers { get; }
    IPlayerState CurrentTurnPlayer { get; }

    IBoardState BoardState { get; }
}
