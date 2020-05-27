public interface IGameState<TCardState, TPlayerState, TBoardState>
    where TCardState : ICardState
    where TPlayerState : IPlayerState<TCardState>
    where TBoardState : IBoardState
{
    TPlayerState UserPlayer { get; }
    TPlayerState[] AllPlayers { get; }
    TPlayerState CurrentTurnPlayer { get; }

    TBoardState BoardState { get; }
}
