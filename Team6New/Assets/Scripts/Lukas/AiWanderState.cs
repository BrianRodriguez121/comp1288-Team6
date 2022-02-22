using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiWanderState : IAiState
{
    float timer = 0.0f;

    public AiStateId GetId()
    {
        return AiStateId.Wander;
    }

    public void Enter(AiAgent agent)
    {
        Debug.Log("wander state");
    }

    public void Exit(AiAgent agent)
    {

    }


    public void Update(AiAgent agent)
    {
        //calculates if player can be seen
        Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;
        Vector3 agentDirection = agent.transform.forward;
        playerDirection.Normalize();
        float dotProduct = Vector3.Dot(playerDirection, agentDirection);

        timer -= Time.deltaTime;

        //random location set as destination for agent 
        if (!agent.navMeshAgent.hasPath || timer <= 0.0f)
        {
            int randumNum = Random.Range(0, 5);
            Debug.Log(randumNum);
            if(randumNum >= 1)
            {
                agent.navMeshAgent.SetDestination(agent.RandomNavmeshLocation(agent.config.wanderRadius));
                timer = agent.config.maxWanderTimer;
            }
            else if(randumNum == 0)
            {
                Debug.Log("Ai has went from wander to idle");
                agent.stateMachine.ChangeState(AiStateId.Idle);
            }

        }

        if (agent.SeenPlayer())
        {
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
        }
    }
}
