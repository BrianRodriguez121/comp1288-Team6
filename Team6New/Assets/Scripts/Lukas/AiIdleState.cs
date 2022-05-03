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
        //agent.IdleTimer();
        agent.detechHealthChange = true;
    }

    public void Exit(AiAgent agent)
    {
        agent.detechHealthChange = false;
    }

    public void Update(AiAgent agent)
    {
        
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            agent.stateMachine.ChangeState(AiStateId.Wander);
        }
        
        if (agent.SensorDetectPlayer() || Vector3.Distance(agent.transform.position, agent.playerTransform.position) < 22)
        {
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
        }

    }
}
