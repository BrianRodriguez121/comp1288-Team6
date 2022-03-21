using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AiAgentConfig : ScriptableObject
{
    public float maxTimer = 1.0f;
    public float maxDistance = 1.0f;
    //public float maxSightDistance = 5.0f;
    public float minWanderRadius = 15.0f;
    public float maxWanderRadius = 40.0f;
    internal float maxWanderTimer = 25.0f;
    internal float maxIdleTimer = 10.0f;
    public float attackStoppingDistance = 15.0f;
    public float findPlayerTimer = 25.0f;
    public float distanceAttackPlayer = 25.0f;
    
    //will regen AI health by 75% of current Health
    public float healthRegenPercent = 1.75f;

    //maxDelta for health increase below 0.5 recomended
    public float healthRegenDuration = 0.3f;
}
