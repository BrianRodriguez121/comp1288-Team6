using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{
    public AiStateMachine stateMachine;
    public AiStateId intialState;
    public NavMeshAgent navMeshAgent;
    public AiAgentConfig config;
    public Transform playerTransform;
    public AiSensor sensor;
    public GameObject attackObjectPrefab;
    public Weapon weaponControl;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        stateMachine = new AiStateMachine(this);
        sensor = GetComponent<AiSensor>();
        weaponControl = GetComponentInChildren<Weapon>();

        stateMachine.RegisterState(new AiIdleState());
        stateMachine.RegisterState(new AiWanderState());
        stateMachine.RegisterState(new AiChasePlayerState());
        stateMachine.RegisterState(new AiAttackState());
        stateMachine.RegisterState(new AiDeathState());
        stateMachine.ChangeState(intialState);

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        stateMachine.Update();
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    public bool SeenPlayer()
    {
        if(sensor.Objects.Count > 0)
        {
            foreach(var obj in sensor.Objects){
                if (obj.layer == 6){
                    Debug.Log("player seen");
                    return true;
                }
            }
        }
        return false;
    }

    public void SpawnItemTest()
    {
        //this is to test for now
        Instantiate(attackObjectPrefab);
    }
    public void DestroyAgent()
    {
        Destroy(gameObject);
    }
}
