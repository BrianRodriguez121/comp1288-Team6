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

    }

    public void Exit(AiAgent agent)
    {

    }

    public void Update(AiAgent agent)
    {
        timer -= Time.deltaTime;

        //random location set as destination for agent 
        if (!agent.navMeshAgent.hasPath || timer <= 0.0f)
        {
            //random chance for AI to Idle
            int randumNum = Random.Range(0, 25);
            //Debug.Log(randumNum);
            if(randumNum >= 1)
            {
                agent.navMeshAgent.SetDestination(agent.RandomNavmeshLocation(agent.config.minWanderRadius, agent.config.maxWanderRadius));
                timer = agent.config.maxWanderTimer;
            }
            else if(randumNum == 0)
            {
                //Debug.Log("Ai has went from wander to idle");
                agent.stateMachine.ChangeState(AiStateId.Idle);
            }
        }

        if (agent.SensorDetectPlayer())
        {
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
        }
    }
}
