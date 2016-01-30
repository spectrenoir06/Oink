using UnityEngine;
using System.Collections;

public class GameState : ApplicationState
{
    private ButtonManager buttonManager;

    public GameState()
    {
        buttonManager = ButtonManager.getInstance();
        if (buttonManager == null)
            Debug.LogError("ERROR: buttonManager is null");
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

        buttonManager.go_gameButton.SetActive(false);
        buttonManager.go_creditButton.SetActive(false);
        buttonManager.go_quitButton.SetActive(false);
        buttonManager.go_backButton.SetActive(true);
    }

    public override void leaveState()
    {
        base.leaveState();

        buttonManager.go_backButton.SetActive(false);
    }
}
