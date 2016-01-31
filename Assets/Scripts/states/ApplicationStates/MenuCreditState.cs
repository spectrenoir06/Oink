using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;

public class MenuCreditState : ApplicationState {

    private UIObjectsContainer uiObjectsContainer;
    private Credits credits;
    private Applicationmanager manager;

    public MenuCreditState()
    {
        uiObjectsContainer = UIObjectsContainer.getInstance();
        if (uiObjectsContainer == null)
            Debug.LogError("ERROR: uiObjectsContainer is null");

        credits = uiObjectsContainer.go_creditText.GetComponent<Credits>();

        manager = Applicationmanager.GetInstance();
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

        manager.waitCredits(true);
        uiObjectsContainer.go_creditText.SetActive(true);
        Camera.main.gameObject.GetComponent<BlurOptimized>().enabled = true;
        credits.showCredits(true);
    }

    public override void leaveState()
    {
        base.leaveState();

        uiObjectsContainer.go_creditText.SetActive(false);
        credits.showCredits(false);
        credits.resetCredits();
        Camera.main.gameObject.GetComponent<BlurOptimized>().enabled = false;
    }
}
