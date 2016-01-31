using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Applicationmanager : MonoBehaviour {

    private static Applicationmanager instance;
    public static Applicationmanager GetInstance()
    {
        if (instance == null)
        {
            GameObject objet = GameObject.Find("ApplicationManagerFinal");
            if (objet == null)
            {
                Debug.LogError("ERROR: there is no ApplicationManager in this scene");
                return null;
            }

            instance = objet.GetComponent<Applicationmanager>();
        }

        return instance;
    }

    private ApplicationStateMachine appliStateMachine;
    public ApplicationStateMachine getAppliStateMachine() { return appliStateMachine; }

    private bool b_waitCredits = false;
    public bool needWatiCredits() { return b_waitCredits; }
    public void waitCredits(bool bo) { b_waitCredits = bo; }

    private float f_timer = 0f;

    // Use this for initialization
    void Start () {
#region applicationStateMachine

        //create the application state machine
        appliStateMachine = new ApplicationStateMachine();

        //register all of the states
        appliStateMachine.registerState(Enum_AppliStateKey.MenuCredit, new MenuCreditState());
        appliStateMachine.registerState(Enum_AppliStateKey.Game, new GameState());
        appliStateMachine.registerState(Enum_AppliStateKey.MenuMain, new MenuMainState());

        //initialize the current state
        appliStateMachine.initCurrentState(Enum_AppliStateKey.MenuMain);

#endregion applicationStateMachine
}

    // Update is called once per frame
    void Update () {

        appliStateMachine.update();

        if (appliStateMachine.CurrentstateKey == Enum_AppliStateKey.MenuCredit)
        {
            f_timer += Time.deltaTime;

            if(f_timer >= 2)
                b_waitCredits = false;

            if (!b_waitCredits && Input.GetMouseButtonDown(0))
                appliStateMachine.changeState(Enum_AppliStateKey.MenuMain);
        }
	}

    public void OnClickGameButton()
    {
        appliStateMachine.changeState(Enum_AppliStateKey.Game);

        SceneManager.LoadSceneAsync("jeu");
    }

    public void OnClickCreditButton()
    {
        appliStateMachine.changeState(Enum_AppliStateKey.MenuCredit);
        f_timer = 0f;
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
        else if (currentStateKey == Enum_AppliStateKey.Game)
        {
            appliStateMachine.changeState(Enum_AppliStateKey.MenuMain);
        }
    }

    public void OnClickQuitGameButton()
    {
        appliStateMachine.changeState(Enum_AppliStateKey.MenuMain);
    }
}
