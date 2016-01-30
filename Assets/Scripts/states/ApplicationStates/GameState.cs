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

        uiObjectsContainer.go_gameButton.SetActive(false);
        uiObjectsContainer.go_creditButton.SetActive(false);
        uiObjectsContainer.go_quitButton.SetActive(false);
        uiObjectsContainer.go_backButton.SetActive(true);
    }

    public override void leaveState()
    {
        base.leaveState();

        uiObjectsContainer.go_backButton.SetActive(false);
    }
}
