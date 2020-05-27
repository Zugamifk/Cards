using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameAction
{
    public abstract IEnumerator DoAction();
}

public class ActionQueueService : IService
{
    Queue<GameAction> m_ActionQueue = new Queue<GameAction>();

    public bool Paused;

    public void QueueAction(GameAction action) {
        m_ActionQueue.Enqueue(action);
    }

    public IEnumerator RunActions()
    {
        while(true)
        {
            while (Paused || m_ActionQueue.Count == 0)
            {
                yield return null;
            }

            var a = m_ActionQueue.Dequeue();

            yield return a.DoAction();
        }
    }
}
