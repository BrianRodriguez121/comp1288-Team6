using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackState : IAiState
{
    public AiStateId GetId()
    {
        return AiStateId.Attack;
    }
    public void Enter(AiAgent agent)
    {

    }

    public void Exit(AiAgent agent)
    {
        agent.HealthRegenCal();
    }

    public void Update(AiAgent agent)
    {
        /*
        //slowed update
        if (agent.SensorDetectPlayer())
        {
            agent.navMeshAgent.destination = agent.playerTransform.position;
            agent.weaponControl.ControlAiInput();
        }*/
        
        //regular update
        agent.shootTimer -= Time.deltaTime;
        if (agent.SensorDetectPlayer())
        {
            agent.navMeshAgent.transform.LookAt(agent.playerTransform);

            if (agent.shootTimer < 0)
            {
                agent.weaponControl.ControlAiInput();
                agent.shootTimer = agent.shootTimerMax;
            }
        }


        // prevents enemy from walking into player when chasing
        if (Vector3.Distance(agent.navMeshAgent.nextPosition, agent.playerTransform.position) < agent.config.attackStoppingDistance)
        {
            agent.navMeshAgent.destination = agent.navMeshAgent.nextPosition;
            // once close enough agent will continue to look at player
            agent.navMeshAgent.transform.LookAt(agent.playerTransform);
        }

        //if to far the AI will go closer to player, can change and improve to find the best place to attack from
        if (Vector3.Distance(agent.navMeshAgent.nextPosition, agent.playerTransform.position) > 40)
        {
            agent.navMeshAgent.destination = agent.playerTransform.position;
            // once cloase enough agent will continue to look at player
            agent.navMeshAgent.transform.LookAt(agent.playerTransform);
        }

        // if sight with player lost - enter chase state
        if (!agent.SensorDetectPlayer())
        {
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
        }

        //condition to enter Hiding State -> hiding place detected within circle range and health above 25% max and below 50% max
        if (agent.health.currentHealth < agent.health.maxHealth / 2 && agent.health.currentHealth > agent.health.maxHealth * 0.25 && agent.SensorDetectHiding())
        {
            agent.stateMachine.ChangeState(AiStateId.Hiding);
        }
    }
}
