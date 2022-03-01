using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiIdleState : IAiState
{
    float timer;
    public AiStateId GetId()
    {
        return AiStateId.Idle;
    }

    public void Enter(AiAgent agent)
    {
        timer = agent.config.maxIdleTimer;
    }

    public void Exit(AiAgent agent)
    {
        
    }

    public void Update(AiAgent agent)
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            agent.stateMachine.ChangeState(AiStateId.Wander);
        }

        if (agent.SensorDetectPlayer())
        {
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
        }

    }
}
