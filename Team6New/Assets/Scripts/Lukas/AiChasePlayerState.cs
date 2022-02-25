using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiChasePlayerState : IAiState
{
    float timer = 0.0f;
    float lostSightTimer = 0.0f;
    bool searchedForPlayer;

    public AiStateId GetId()
    {
        return AiStateId.ChasePlayer;
    }

    public void Enter(AiAgent agent)
    {
        Debug.Log("chase state");
        lostSightTimer = 10.0f;
    }

    public void Exit(AiAgent agent)
    {

    }

    public void Update(AiAgent agent)
    {
        if (!agent.enabled) { 
            return;
        }

        timer -= Time.deltaTime;

        if (agent.SeenPlayer())
        {
            lostSightTimer = agent.config.findPlayerTimer;
            searchedForPlayer = false;

            if(Vector3.Distance(agent.transform.position, agent.playerTransform.position)< agent.config.distanceAttackPlayer)
            {

                agent.stateMachine.ChangeState(AiStateId.Attack);
            }
        }

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

        //if AI loses sight they first search area last seen
        if (!agent.SeenPlayer())
        {
            lostSightTimer -= Time.deltaTime;

            if (!searchedForPlayer)
            {
                searchedForPlayer = true;
                //this makes AI continue to chase player until timer has run out
                agent.navMeshAgent.destination = agent.playerTransform.position;
            }
            
            if (lostSightTimer <= 0)
            {
                searchedForPlayer = false;
                agent.stateMachine.ChangeState(AiStateId.Wander);
                Debug.Log("Timer ran out and no longer chasing");
            }
        }
    }
}
