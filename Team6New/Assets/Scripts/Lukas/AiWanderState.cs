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
        timer -= Time.deltaTime;
        //Debug.Log(timer);

        if (!agent.navMeshAgent.hasPath || timer <= 0.0f)
        {
            Debug.Log("new navemesh wander location");
            agent.navMeshAgent.SetDestination(agent.RandomNavmeshLocation(agent.config.wanderRadius));
            timer = agent.config.maxWanderTimer;
        }
    }

}
