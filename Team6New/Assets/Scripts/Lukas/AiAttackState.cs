using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackState : IAiState
{
    public AiStateId GetId()
    {
        return AiStateId.Attack;
    }
    public void Enter(AiAgent agent)
    {
        throw new System.NotImplementedException();
    }

    public void Exit(AiAgent agent)
    {
        throw new System.NotImplementedException();
    }

    public void Update(AiAgent agent)
    {
        if (agent.SeenPlayer())
        {
            agent.SpawnItemTest();
        }
    }
}
