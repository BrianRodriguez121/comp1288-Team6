using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiIdleState : IAiState
{
    public AiStateId GetId()
    {
        return AiStateId.Idle;
    }

    public void Enter(AiAgent agent)
    {
        Debug.Log("idle state");
    }

    public void Exit(AiAgent agent)
    {
        
    }

    public void Update(AiAgent agent)
    {
        Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;

        if(playerDirection.magnitude > agent.config.maxSightDistance)
        {
            return;
        }

        Vector3 agentDirection = agent.transform.forward;
        playerDirection.Normalize();


        if(agent.SeenPlayer())
        {
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
        }

    }
}
