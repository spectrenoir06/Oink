using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;

public class MenuCreditState : ApplicationState {

    private UIObjectsContainer uiObjectsContainer;
    private Credits credits;

    public MenuCreditState()
    {
        uiObjectsContainer = UIObjectsContainer.getInstance();
        if (uiObjectsContainer == null)
            Debug.LogError("ERROR: uiObjectsContainer is null");

        credits = uiObjectsContainer.go_creditText.GetComponent<Credits>();
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
        uiObjectsContainer.go_ruleButton.SetActive(false);
        uiObjectsContainer.go_quitGameButton.SetActive(false);

        uiObjectsContainer.go_backButton.SetActive(true);
        uiObjectsContainer.go_creditText.SetActive(true);

        Camera.main.gameObject.GetComponent<BlurOptimized>().enabled = true;
        credits.showCredits(true);
    }

    public override void leaveState()
    {
        base.leaveState();

        uiObjectsContainer.go_backButton.SetActive(false);
        uiObjectsContainer.go_creditText.SetActive(false);

        credits.showCredits(false);
        credits.resetCredits();
        Camera.main.gameObject.GetComponent<BlurOptimized>().enabled = false;
    }
}
