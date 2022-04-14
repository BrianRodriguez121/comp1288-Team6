using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyType
{
    Normal,
    Boss
}

public class AiAgent : MonoBehaviour
{
    public EnemyType enemyType = EnemyType.Normal;

    public float healthRegenAmount; 
    public float shootTimer; 
    public float shootTimerMax = 2; 

    public AiStateMachine stateMachine;
    public AiStateId intialState;
    public NavMeshAgent navMeshAgent;
    public AiAgentConfig config;
    public Transform playerTransform;
    Transform agentTransform;
    public AiSensor sensor;
    public WeaponSystem weaponSystem;

    public Weapon weaponControl;
    public Health health;
    public FPSController playerController;

    public GameObject heatMapPrefab;

    [HideInInspector]
    public bool detechHealthChange;

    void Start()
    {
        playerController = FindObjectOfType<FPSController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        stateMachine = new AiStateMachine(this);
        sensor = GetComponentInChildren<AiSensor>();
        weaponSystem = GetComponentInChildren<WeaponSystem>();
        
        if(enemyType == EnemyType.Normal)
        {
            weaponControl = GetComponentInChildren<Weapon>();
        }
        else 
        {
            weaponControl = weaponSystem.GetWeaponCompenet(weaponSystem.weaponIndex);
        }

        health = GetComponent<Health>();

        stateMachine.RegisterState(new AiIdleState());
        stateMachine.RegisterState(new AiWanderState());
        stateMachine.RegisterState(new AiChasePlayerState());
        stateMachine.RegisterState(new AiAttackState());
        stateMachine.RegisterState(new AiHidingState());
        stateMachine.RegisterState(new AiDeathState());
        stateMachine.ChangeState(intialState);

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        agentTransform = GetComponent<Transform>();

        shootTimer = shootTimerMax;

        //InvokeRepeating(nameof(UpdateMethod), 0.05f, 0.1f);
        //InvokeRepeating(nameof(UpdateMethod), Random.Range(0.01f, 0.09f), 0.1f);
    }
    
    void Update()
    {
        stateMachine.Update();
        
        //checks if the active weapon index has changed to update attached Weapon script
        if(enemyType == EnemyType.Boss)
        {
            weaponControl = weaponSystem.GetWeaponCompenet(weaponSystem.weaponIndex);
        }
    }
    /*
    void UpdateMethod()
    {
        stateMachine.Update();
    }
    */

    // find a random location on the navmesh around AI if bool true, else finds random location around player for attack position
    public Vector3 NewNavmeshLocationDestination(float minRadius, float maxRadius, bool randomWander)
    {
        //for random location around AI
        if(randomWander == true)
        {
            Vector3 randomDirection = Random.insideUnitSphere.normalized * Random.Range(minRadius, maxRadius);
            randomDirection += transform.position;
            NavMeshHit hit;
            Vector3 finalPosition = Vector3.zero;
            if (NavMesh.SamplePosition(randomDirection, out hit, maxRadius, 1))
            {
                finalPosition = hit.position;
            }
            return finalPosition;
        }
        //for random location around player for Attack state
        else if(randomWander == false)
        {
            Vector3 randomDirection = Random.insideUnitSphere.normalized * Random.Range(minRadius, maxRadius);
            randomDirection += playerTransform.position;
            NavMeshHit hit;
            Vector3 finalPosition = Vector3.zero;
            if (NavMesh.SamplePosition(randomDirection, out hit, maxRadius, 1))
            {
                finalPosition = hit.position;
            }
            return finalPosition;
        }
        return agentTransform.position;
    } 

    //Using AiSensor - checks if Player can be seen
    public bool SensorDetectPlayer()
    {
        if(sensor.Objects.Count > 0)
        {
            foreach(var obj in sensor.Objects)
            {
                if (obj.layer == 6){
                    //Debug.Log("player seen");
                    return true;
                }
            }
        }
        return false;
    }

    //Using AiSensor - checks if Hiding is within vision circle
    public bool SensorDetectHiding()
    {
        if(sensor.AllHidingSpots.Count > 0)
        {
            foreach(var obj in sensor.AllHidingSpots)
            {
                if (obj.layer == 7){
                    //Debug.Log("player seen");
                    return true;
                }
            }
        }
        return false;
    }

    //Returns the closest Hiding spots in radius of the AI 
    public GameObject DetectHidingPlace()
    {
        if (sensor.AllHidingSpots.Count > 0)
        {
            GameObject bestTarget = null;
            float closestDistanceSqr = Mathf.Infinity;
            Vector3 currentPosition = transform.position;

            foreach (var obj in sensor.AllHidingSpots)
            {
                if (obj.layer == 7 /*&& !FPSController.SeenHidingSpots.Contains(obj)*/)
                {
                    Vector3 directionToTarget = obj.transform.position - currentPosition;
                    float dSqrToTarget = directionToTarget.sqrMagnitude;
                    if (dSqrToTarget < closestDistanceSqr)
                    {
                        closestDistanceSqr = dSqrToTarget;
                        bestTarget = obj;
                    }
                    return bestTarget;
                }
            }
        }
        return null;
    }

    //On state exit health regen is calculated once
    public void HealthRegenCal()
    {
        healthRegenAmount = health.currentHealth * config.healthRegenPercent;
    }

    public void DestroyAgent()
    {
        if (playerController.heatMap)
        {
            GameObject killMark = Instantiate(heatMapPrefab, agentTransform.position, agentTransform.rotation);
            killMark.transform.parent = playerController.heatMapParent.transform;
        }

        Destroy(gameObject);
    }
    /*
    public void IdleTimer()
    {
        if (stateMachine.currentState == AiStateId.Idle)
        {
            Invoke(nameof(ChangeState), config.maxIdleTimer);
        }
    }

    void ChangeState()
    {
        stateMachine.ChangeState(AiStateId.Wander);
    }*/
}
