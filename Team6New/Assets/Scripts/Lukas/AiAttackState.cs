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

        if(agent.enemyType == EnemyType.Normal)
        {
            //regular update
            
            if (agent.SensorDetectPlayer())
            {
                agent.shootTimer -= Time.deltaTime;
                //prevents AI from rotating on y axis
                var lookDirection = new Vector3(agent.playerTransform.position.x, agent.transform.position.y, agent.playerTransform.position.z);
                agent.navMeshAgent.transform.LookAt(lookDirection);

                //allows for weapon to aim at player (helps with height difference)
                agent.weaponControl.transform.LookAt(agent.playerTransform);

                if (agent.shootTimer < 0)
                {
                    agent.weaponControl.ControlAiInput();
                    agent.shootTimer = agent.shootTimerMax;
                }
            }

            // prevents enemy from walking into player when chasing
            if (Vector3.Distance(agent.navMeshAgent.nextPosition, agent.playerTransform.position) < agent.config.attackStoppingDistance)
            {
                agent.navMeshAgent.destination = agent.NewNavmeshLocationDestination(30, 60, false);
            }

            //if too far the AI will go closer to player, can change and improve to find the best place to attack from
            if (Vector3.Distance(agent.navMeshAgent.nextPosition, agent.playerTransform.position) > 39)
            {
                agent.navMeshAgent.destination = agent.NewNavmeshLocationDestination(30, 70, false);
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


        //Attack behaviour for Boss AI
        else if(agent.enemyType == EnemyType.Boss)
        {
            if (agent.SensorDetectPlayer())
            {
                //prevents AI from rotating on y axis
                var lookDirection = new Vector3(agent.playerTransform.position.x, agent.transform.position.y, agent.playerTransform.position.z);
                agent.navMeshAgent.transform.LookAt(lookDirection);

                //allows for weapon to aim at player (helps with height difference)
                agent.weaponSystem.transform.LookAt(agent.playerTransform);

                if(Vector3.Distance(agent.navMeshAgent.nextPosition, agent.playerTransform.position) < 50)
                {
                    agent.shootTimer -= Time.deltaTime;
                    agent.weaponSystem.SetActiveWeapon(1);
                    agent.shootTimerMax = 2.2f;
                    if (agent.shootTimer < 0)
                    {
                        agent.weaponControl.ControlAiInput();
                        agent.shootTimer = agent.shootTimerMax;
                    }
                }
                else if(Vector3.Distance(agent.navMeshAgent.nextPosition, agent.playerTransform.position) > 50)
                {
                    agent.shootTimer -= Time.deltaTime;
                    agent.weaponSystem.SetActiveWeapon(0);
                    agent.shootTimerMax = 0.5f;

                    if (agent.shootTimer < 0)
                    {
                        agent.weaponControl.ControlAiInput();
                        agent.shootTimer = agent.shootTimerMax;
                    }
                }
            }

            //if too far the AI will go closer to player, can change and improve to find the best place to attack from
            if (Vector3.Distance(agent.navMeshAgent.nextPosition, agent.playerTransform.position) > 80)
            {
                agent.navMeshAgent.destination = agent.NewNavmeshLocationDestination(40, 100, false);
                agent.navMeshAgent.transform.LookAt(agent.playerTransform);
            }

            // prevents enemy from walking into player when chasing
            if (Vector3.Distance(agent.navMeshAgent.nextPosition, agent.playerTransform.position) < agent.config.attackStoppingDistance)
            {
                agent.navMeshAgent.destination = agent.NewNavmeshLocationDestination(20, 100, false);
            }
            // if sight with player lost - enter chase state
            if (!agent.SensorDetectPlayer())
            {
                agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
            }
        }

    }
}
