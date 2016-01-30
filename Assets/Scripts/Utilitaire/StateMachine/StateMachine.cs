using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateMachine<T, U> where U : State
{
    private Dictionary<T, U> stateDictionnary;

    private T currentStateName;
    public T CurrentstateName
    { get { return currentStateName; } }

    private U currentState;
    public U CurrentState
    { get { return currentState; } }

    public StateMachine()
    {
        stateDictionnary = new Dictionary<T, U>();
    }

    public void registerState(T name, U state)
    {
        stateDictionnary.Add(name, state);
    }

    public void initCurrentState(T name)
    {
        currentStateName = name;
        currentState = stateDictionnary[name];
        currentState.enterState(currentState);
    }

    public void update()
    {
        currentState.update();
    }

    public void fixedUpdate()
    {
        currentState.fixedUpdate();
    }

    public void changeState(T newState)
    {
        currentStateName = newState;
        currentState.leaveState();
        stateDictionnary[newState].enterState(currentState);
        currentState = stateDictionnary[newState];
    }

    public bool hasState(T identifier)
    {
        return stateDictionnary.ContainsKey(identifier);
    }
}
