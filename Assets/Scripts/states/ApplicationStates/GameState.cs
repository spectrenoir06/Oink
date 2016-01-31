using UnityEngine;
using System.Collections;

public class GameState : ApplicationState
{
    private UIObjectsContainer uiObjectsContainer;

    public GameState()
    {
        uiObjectsContainer = UIObjectsContainer.getInstance();
        if (uiObjectsContainer == null)
            Debug.LogError("ERROR: uiObjectsContainer is null");
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

        uiObjectsContainer.go_creditText.SetActive(false);
    }

    public override void leaveState()
    {
        base.leaveState();
    }
}
