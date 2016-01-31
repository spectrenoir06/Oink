using NLua;
using UnityEngine;
using System.Collections;

public class NPCAIState : State
{
    protected NPCAIController controller;
    public Transform transform;
    protected TextAsset scriptAsset;
    protected LuaEnvironnement lua;

    public NPCAIState(NPCAIController controller, Transform transform, LuaEnvironnement luaEnvironnement, TextAsset script)
    {
        lua = luaEnvironnement;
        this.controller = controller;
        this.transform = transform;

        scriptAsset = script;
    }

    public virtual void update()
    {

    }

    public virtual void enterState(State previousState)
    {
        lua.doString(scriptAsset.text, transform.name + "-" + scriptAsset.name);
        lua.call("enter", this);
    }

    public virtual void leaveState()
    {
        lua.call("leave", this);
    }

    public virtual void fixedUpdate()
    {
        lua.call("update", this);
    }

    public void changeState(string newState)
    {
        controller.changeState(newState);
    }

    public void goTo(Transform goal)
    {
        transform.position = Vector3.MoveTowards(transform.position, goal.position, .03f);
    }

    public bool hasState(string stateName)
    {
        return controller.hasState(stateName);
    }
}
