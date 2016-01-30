using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuCreditState : ApplicationState {

    public List<string> list_creditItems = new List<string>();

    private ButtonManager buttonManager;
    private GameObject go_creditText;

    public MenuCreditState()
    {
        buttonManager = ButtonManager.getInstance();
        if (buttonManager == null)
            Debug.LogError("ERROR: buttonManager is null");

        go_creditText = GlobalVariables.GO_CREDIT_TEXT;
        if (go_creditText == null)
            Debug.LogError("ERROR: creditText is null");

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
        go_creditText.SetActive(true);
    }

    public override void leaveState()
    {
        base.leaveState();

        buttonManager.go_backButton.SetActive(false);
        go_creditText.SetActive(false);
    }
}
