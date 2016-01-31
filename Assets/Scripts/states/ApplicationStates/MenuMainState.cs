using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuMainState : ApplicationState
{

    public List<string> list_creditItems = new List<string>();
    private UIObjectsContainer uiObjectsContainer;

    public MenuMainState()
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

        uiObjectsContainer.go_creditText.SetActive(false);
    }

    public override void leaveState()
    {
        base.leaveState();
    }
}
