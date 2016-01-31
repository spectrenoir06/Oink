using NLua;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCAIController : MonoBehaviour
{
    [SerializeField]
    private TextAsset startState;
    [SerializeField]
    private PinguinAnimator animator;

    [SerializeField]
    private List<TextAsset> stateList;

    [SerializeField]
    private Pingouin pingouin;
    
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

    public void notifytouchGround()
    {
        (stateMachine.CurrentState as PingouinAIState).notifytouchGround();
    }

    public void throwFish()
    {
        pingouin.throwFish();
    }
    
    public void startWalking()
    {
        (stateMachine.CurrentState as PingouinAIState).onAnimEnd();
    }
  
    public void playAnimation(string name)
    {
        if (name == "dance&eat")
            animator.playAnimation(PinguinAnimator.newStateAnimationPinguin.DanceThenEat);
        else if (name == "eat")
            animator.playAnimation(PinguinAnimator.newStateAnimationPinguin.Eat);
        else if(name == "dance&dive")
            animator.playAnimation(PinguinAnimator.newStateAnimationPinguin.DanceThenDive);
        else if (name == "eat")
            animator.playAnimation(PinguinAnimator.newStateAnimationPinguin.Dive);
    }

    public void onBorderBanquise()
    {
        (stateMachine.CurrentState as PingouinAIState).onBorderBanquise();
    }
}
