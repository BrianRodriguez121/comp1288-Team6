using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackState : IAiState
{
    float timer = 1.5f;
    public AiStateId GetId()
    {
        return AiStateId.Attack;
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

        if (agent.SeenPlayer() && timer < 0)
        {
            //agent.SpawnItemTest();
            agent.navMeshAgent.transform.LookAt(agent.playerTransform);
            agent.weaponControl.ControlAiInput();
            timer = 1.5f;
        }

        // prevents enemy from walking into player when chasing
        if (Vector3.Distance(agent.navMeshAgent.nextPosition, agent.playerTransform.position) < agent.config.attackStoppingDistance)
        {
            agent.navMeshAgent.destination = agent.navMeshAgent.nextPosition;
            // once cloase enough agent will continue to look at player
            agent.navMeshAgent.transform.LookAt(agent.playerTransform);
        }

        if (!agent.SeenPlayer())
        {
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
        }


    }
}
