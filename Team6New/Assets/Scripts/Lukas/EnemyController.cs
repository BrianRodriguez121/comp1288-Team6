using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

enum STATE
{
    WANDER,
    ATTACK,
    CHASE,
    DEAD
}

public class EnemyController : MonoBehaviour
{
    /*
    public GameObject target;
    public float walkingSpeed;
    public float runningSpeed;
    NavMeshAgent agent;
    float lifetime = 5.0f;
    public float damageAmount = 5;
    Collider col;

    public float inDamageTime = 0.5f;
    float damageTime = 0.0f;


    public GameObject player;

    private float wanderTimer = 8.0f;
    private float timer;



    STATE state = STATE.WANDER;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        col = GetComponent<Collider>();
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        damageTime = inDamageTime;
    }
    
    float DistanceToPlayer()
    {
        return Vector3.Distance(target.transform.position, this.transform.position);
    }

    bool CanSeePlayer(float distance)
    {
        if (DistanceToPlayer() < distance)
            return true;
        return false;
    }

    bool ForgetPlayer(float distanceAway)
    {
        if (DistanceToPlayer() > distanceAway)
            return true;
        return false;
    }
    
    public void KillEnemy()
    {
        col.enabled = !col.enabled;
        state = STATE.DEAD;
    }

    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
        }

        timer += Time.deltaTime;

        switch (state)
        {
            case STATE.WANDER:
                Wander();
                break;
            case STATE.CHASE:
                Chase();
                break;
            case STATE.ATTACK:
                Attack();
                break;
            case STATE.DEAD:
                Dead();
                break;
        }
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
    void Wander()
    {

        
        if (!agent.hasPath || timer >= wanderTimer)
        {
            agent.SetDestination(RandomNavmeshLocation(8f));
            agent.stoppingDistance = 0.5f;
            agent.speed = walkingSpeed;

            timer = 0;
        }
        
        if (CanSeePlayer(20))
        {
            state = STATE.CHASE;
        }
        
    }
    void Chase()
    {
        agent.SetDestination(target.transform.position);
        agent.stoppingDistance = 5;
        agent.speed = runningSpeed;
        
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            state = STATE.ATTACK;
        }
        
        if (ForgetPlayer(30))
        {
            state = STATE.WANDER;
            agent.ResetPath();
        }
    }
    void Attack()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(targetPosition);

        damageTime -= Time.deltaTime;

        if (damageTime < 0)
            damageTime = 0;

        if (DistanceToPlayer() < 8 && damageTime == 0)
        {
            player.GetComponent<Health>().TakeHit(damageAmount);
            damageTime = inDamageTime;
        }

        if (DistanceToPlayer() > agent.stoppingDistance + 2)
        {
            state = STATE.CHASE;
        }
    }

    void Dead()
    {
        agent.SetDestination(transform.position);
        Destroy(gameObject, lifetime);
    }
    */
}
