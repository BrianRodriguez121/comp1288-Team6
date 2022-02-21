using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiChasePlayerState : IAiState
{
    float timer = 0.0f;
    float lostSightPlayer = 0.0f;

    public AiStateId GetId()
    {
        return AiStateId.ChasePlayer;
    }

    public void Enter(AiAgent agent)
    {
        lostSightPlayer = 10.0f;
    }

    public void Exit(AiAgent agent)
    {

    }

    public void Update(AiAgent agent)
    {
        Debug.Log("chase state");

        if (!agent.enabled) { 
            return;
        }

        timer -= Time.deltaTime;
        

        if (!agent.navMeshAgent.hasPath)
        {
            agent.navMeshAgent.destination = agent.playerTransform.position;
        }

        // prevents enemy from walking into player when chasing
        if(Vector3.Distance(agent.navMeshAgent.nextPosition, agent.playerTransform.position) < agent.config.stoppingDistance)
        {
            agent.navMeshAgent.destination = agent.navMeshAgent.nextPosition;

            // once cloase enough agent will continue to look at player
            agent.navMeshAgent.transform.LookAt(agent.playerTransform);
        }

        if (timer < 0.0f)
        {
            Vector3 direction = (agent.playerTransform.position - agent.navMeshAgent.destination);
            direction.y = 0;
            if(direction.sqrMagnitude > agent.config.maxDistance * agent.config.maxDistance)
            {
                if(agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {
                    agent.navMeshAgent.destination = agent.playerTransform.position;
                }
            }
            timer = agent.config.maxTimer;
        }

        if (!agent.SeenPlayer())
        {
            agent.stateMachine.ChangeState(AiStateId.Wander);
            Debug.Log("stopped seeing the player");
        }
    }
}
