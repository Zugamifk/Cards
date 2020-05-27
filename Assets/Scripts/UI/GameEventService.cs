using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEventService : IService, IConstructableService
{
    public event Action<ICardState> OnDragCard;
    public void DraggedCard(ICardState card) => OnDragCard?.Invoke(card);

    public event Action<ICardState> OnReleaseCard;

    public event Action<ICardState> OnDrawCard;
}
