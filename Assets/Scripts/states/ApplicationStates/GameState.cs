using UnityEngine;
using System.Collections;

public class GameState : ApplicationState
{
    public GameState()
    {

    }

	// Use this for initialization
	void Start () {
	
	}

    public override void update()
    {
        base.update();
    }

    public override void fixedUpdate()
    {
        base.fixedUpdate();
    }

    public override void enterState(State previousState)
    {
        base.enterState(previousState);
    }

    public override void leaveState()
    {
        base.leaveState();
    }
}
