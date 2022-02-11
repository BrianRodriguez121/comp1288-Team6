using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiStateMachine
{
    public IAiState[] states;
    public AiAgent agent;
    public AiStateId currentState;

    public AiStateMachine(AiAgent agent)
    {
        this.agent = agent;
        int numStates = System.Enum.GetNames(typeof(AiStateId)).Length;
        states = new IAiState[numStates];
    }

    public void RegisterState(IAiState state)
    {
        int index = (int)state.GetId();
        states[index] = state;
    }

    public IAiState GetState(AiStateId stateId)
    {
        int index = (int)stateId;
        return states[index];
    }

    public void Update()
    {
        GetState(currentState)?.Update(agent);
    }

    public void ChangeState(AiStateId newState)
    {
        GetState(currentState)?.Exit(agent);
        currentState = newState;
        GetState(currentState)?.Enter(agent);
    }
}
