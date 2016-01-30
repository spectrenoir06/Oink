using NLua;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCAIController : MonoBehaviour
{
    [SerializeField]
    private TextAsset startState;

    [SerializeField]
    private List<TextAsset> stateList;
    
    StateMachine<string, NPCAIState> stateMachine;
    private string iaScript;
    private NPCAIState state;
    LuaEnvironnement lua;

    void Awake()
    {

    }

    void Start()
    {
        lua = LuaEnvironnement.CreateEnvironement();
        stateMachine = new StateMachine<string, NPCAIState>();
        stateMachine.registerState(startState.name, new PingouinAIState(this, transform, lua, startState));
        foreach (TextAsset text in stateList)
        {
            stateMachine.registerState(text.name, new PingouinAIState(this, transform, lua, text));
        }
        stateMachine.initCurrentState(startState.name);
    }

    void Update()
    {
        stateMachine.update();
    }

    void FixedUpdate()
    {
        stateMachine.fixedUpdate();
    }

    public void changeState(string newState)
    {
        StartCoroutine(changeStateCoroutine(newState));
    }

    public IEnumerator changeStateCoroutine(string newState)
    {
        yield return new WaitForEndOfFrame();
        stateMachine.changeState(newState);
    }

    public bool hasState(string stateName)
    {
        return stateMachine.hasState(stateName);
    }
}
