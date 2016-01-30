using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateMachine<T, U> where U : State
{
    private Dictionary<T, U> stateDictionnary;

    private T currentStateKey;
    public T CurrentstateKey
    { get { return currentStateKey; } }

    private U currentState;
    public U CurrentState
    { get { return currentState; } }

    public StateMachine()
    {
        stateDictionnary = new Dictionary<T, U>();
    }

    public void registerState(T key, U state)
    {
        stateDictionnary.Add(key, state);
    }

    public void initCurrentState(T key)
    {
        currentStateKey = key;
        currentState = stateDictionnary[key];
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
        currentStateKey = newState;
        currentState.leaveState();
        stateDictionnary[newState].enterState(currentState);
        currentState = stateDictionnary[newState];
    }

    public bool hasState(T identifier)
    {
        return stateDictionnary.ContainsKey(identifier);
    }
}
