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
        //Debug.Log("idle state");
    }

    public void Exit(AiAgent agent)
    {
        
    }

    public void Update(AiAgent agent)
    {
        timer -= Time.deltaTime;
        /*
        Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;

        if(playerDirection.magnitude > agent.config.maxSightDistance)
        {
            return;
        }

        Vector3 agentDirection = agent.transform.forward;
        playerDirection.Normalize();
        */
        if(timer <= 0)
        {
            agent.stateMachine.ChangeState(AiStateId.Wander);
        }

        if (agent.SeenPlayer())
        {
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
        }

    }
}
