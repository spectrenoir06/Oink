using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Applicationmanager : MonoBehaviour {

    private ApplicationStateMachine appliStateMachine;
    private InGameStateMachine inGameStateMachine;


    // Use this for initialization
    void Start () {
#region applicationStateMachine

        //create the application state machine
        appliStateMachine = new ApplicationStateMachine();

        //register all of the states
        appliStateMachine.registerState(Enum_AppliStateKey.MenuCredit, new MenuCreditState());
        appliStateMachine.registerState(Enum_AppliStateKey.Game, new GameState());
        appliStateMachine.registerState(Enum_AppliStateKey.MenuMain, new MenuMainState());
        appliStateMachine.registerState(Enum_AppliStateKey.MenuRule, new MenuRuleState());

        //initialize the current state
        appliStateMachine.initCurrentState(Enum_AppliStateKey.MenuMain);

#endregion applicationStateMachine

#region InGameStateMachine


#endregion InGameStateMachine

    }

    // Update is called once per frame
    void Update () {
        appliStateMachine.update();
	}

    public void OnClickGameButton()
    {
        appliStateMachine.changeState(Enum_AppliStateKey.Game);
    }

    public void OnClickCreditButton()
    {
        appliStateMachine.changeState(Enum_AppliStateKey.MenuCredit);
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }

    public void OnClickBackButton()
    {
        Enum_AppliStateKey currentStateKey = appliStateMachine.CurrentstateKey;
        if (currentStateKey == Enum_AppliStateKey.MenuCredit)
        {
            appliStateMachine.changeState(Enum_AppliStateKey.MenuMain);
        }
        else if (currentStateKey == Enum_AppliStateKey.MenuRule)
        {
            appliStateMachine.changeState(Enum_AppliStateKey.MenuMain);
        }
        else if (currentStateKey == Enum_AppliStateKey.Game)
        {
            appliStateMachine.changeState(Enum_AppliStateKey.MenuMain);
        }
    }

    public void OnClickRuleButton()
    {
        appliStateMachine.changeState(Enum_AppliStateKey.MenuRule);
    }

    public void OnClickQuitGameButton()
    {
        appliStateMachine.changeState(Enum_AppliStateKey.MenuMain);
    }
}
