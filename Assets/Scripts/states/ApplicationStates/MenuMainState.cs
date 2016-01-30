using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuMainState : ApplicationState
{

    public List<string> list_creditItems = new List<string>();
    private ButtonManager buttonManager;

    public MenuMainState()
    {
        buttonManager = ButtonManager.getInstance();
        if (buttonManager == null)
            Debug.LogError("ERROR: buttonManager is null");
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

        buttonManager.go_gameButton.SetActive(true);
        buttonManager.go_creditButton.SetActive(true);
        buttonManager.go_quitButton.SetActive(true);
        buttonManager.go_backButton.SetActive(false);
    }

    public override void leaveState()
    {
        base.leaveState();

        buttonManager.go_gameButton.SetActive(false);
        buttonManager.go_creditButton.SetActive(false);
        buttonManager.go_quitButton.SetActive(false);
        buttonManager.go_backButton.SetActive(false);
    }
}
