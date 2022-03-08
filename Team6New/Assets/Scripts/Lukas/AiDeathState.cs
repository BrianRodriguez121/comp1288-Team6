using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDeathState : IAiState
{
    public AiStateId GetId()
    {
        return AiStateId.Death;
    }
    public void Enter(AiAgent agent)
    {
        Debug.Log("death state entered");
        agent.DestroyAgent();
    }

    public void Exit(AiAgent agent)
    {

    }

    public void Update(AiAgent agent)
    {

    }
}
