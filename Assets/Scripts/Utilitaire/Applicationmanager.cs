using UnityEngine;
using System.Collections;

public class Applicationmanager : MonoBehaviour {

    private ApplicationStateMachine appliStateMachine;

	// Use this for initialization
	void Start () {
        //create the application state machine
        appliStateMachine = new ApplicationStateMachine();

        //register all of the states
        appliStateMachine.registerState(Enum_AppliStateKey.Credit, new CreditState());
        appliStateMachine.registerState(Enum_AppliStateKey.Game, new GameState());
        appliStateMachine.registerState(Enum_AppliStateKey.Quit, new QuitState());

        //initialize the current state
        appliStateMachine.initCurrentState(Enum_AppliStateKey.Credit);
	}

	// Update is called once per frame
	void Update () {
        switch (appliStateMachine.CurrentstateKey)
        {
            case Enum_AppliStateKey.Credit :
                appliStateMachine.CurrentState.update();
                break;
            case Enum_AppliStateKey.Game :
                appliStateMachine.CurrentState.update();
                break;
            case Enum_AppliStateKey.Quit :
                appliStateMachine.CurrentState.update();
                break;
            default:
                break;
        }
	}

    public void OnClickGameButton()
    {
        appliStateMachine.changeState(Enum_AppliStateKey.Game);
    }

    public void OnClickCreditButton()
    {
        appliStateMachine.changeState(Enum_AppliStateKey.Credit);
    }

    public void OnClickQuitButton()
    {
        appliStateMachine.changeState(Enum_AppliStateKey.Quit);
    }

    public ApplicationStateMachine getAppliStateMachine()
    {
        return appliStateMachine;
    }
}
