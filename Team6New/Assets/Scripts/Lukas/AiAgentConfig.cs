using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AiAgentConfig : ScriptableObject
{
    public float maxTimer = 1.0f;
    public float maxDistance = 1.0f;
    public float maxSightDistance = 5.0f;
    public float wanderRadius = 20.0f;
    internal float maxWanderTimer = 20.0f;
    public float stoppingDistance = 5.0f;
    public float seePlayerDistance = 25.0f;
}
