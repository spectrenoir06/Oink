using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuRuleState : ApplicationState
{

    public List<string> list_creditItems = new List<string>();

    private UIObjectsContainer uiObjectsContainer;

    public MenuRuleState()
    {
        uiObjectsContainer = UIObjectsContainer.getInstance();
        if (uiObjectsContainer == null)
            Debug.LogError("ERROR: uiObjectsContainer is null");
    }

    // Use this for initialization
    void Start()
    {

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
        uiObjectsContainer.go_creditText.SetActive(false);
        uiObjectsContainer.go_ruleButton.SetActive(false);
        uiObjectsContainer.go_quitGameButton.SetActive(false);

        uiObjectsContainer.go_backButton.SetActive(true);
    }

    public override void leaveState()
    {
        base.leaveState();

        uiObjectsContainer.go_backButton.SetActive(false);
    }
}
