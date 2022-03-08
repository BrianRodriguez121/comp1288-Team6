using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHidingState : IAiState
{
    bool inHiding;
    public AiStateId GetId()
    {
        return AiStateId.Hiding;
    }

    public void Enter(AiAgent agent)
    {
        
    }

    public void Exit(AiAgent agent)
    {
        inHiding = false;
    }


    public void Update(AiAgent agent)
    {
        //Checks if AI has hiding spot around it
        if (agent.SensorDetectHiding() && !inHiding)
        {
            GameObject hidingSpot = agent.DetectHidingPlace();
            agent.navMeshAgent.SetDestination(hidingSpot.transform.position);
            //agent.playerController.SensorDetectHiding();
            inHiding = true;
        }

        //if statements check if AI has reached hidding spot
        if (agent.navMeshAgent.remainingDistance <= agent.navMeshAgent.stoppingDistance)
        {
            if (!agent.navMeshAgent.hasPath || agent.navMeshAgent.velocity.sqrMagnitude == 0f)
            {
                agent.health.currentHealth = (float)Mathf.MoveTowards(agent.health.currentHealth, agent.healthRegenAmount, agent.config.healthRegenDuration);
                agent.navMeshAgent.transform.LookAt(agent.playerTransform);
            }
        }

        // if regen top reached or player seen -> enter attack state
        if (agent.health.currentHealth >= agent.healthRegenAmount  || agent.SensorDetectPlayer())
        {
            agent.stateMachine.ChangeState(AiStateId.Attack);
        }
    }
}
