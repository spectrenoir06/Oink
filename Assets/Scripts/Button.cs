using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum Enum_ButtonType
{
    Non,
    PlayGame,
    MenuCredit,
    QuitGame
}

public class Button : MonoBehaviour {

    public Enum_ButtonType buttonType = Enum_ButtonType.Non;
    private Applicationmanager manager;
    private bool b_quit = false;
    private Ray ray;
    RaycastHit[] hits;
    MeshRenderer renderer;

    // Use this for initialization
    void Start () {
        manager = Applicationmanager.GetInstance();
        renderer = gameObject.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hits = Physics.RaycastAll(ray, 100);

        for (int i = 0; i < hits.Length; ++i)
        {
            if (hits[i].transform == gameObject.transform)
            {
                switch (buttonType)
                {
                    case Enum_ButtonType.PlayGame:
                        if (Input.GetKeyUp(KeyCode.Mouse0) && manager.getAppliStateMachine().CurrentstateKey != Enum_AppliStateKey.Game)
                        {
                            manager.OnClickGameButton();

                            Debug.Log("Play button clicked");
                        }

                        break;
                    case Enum_ButtonType.MenuCredit:
                        if (Input.GetKeyUp(KeyCode.Mouse0) && manager.getAppliStateMachine().CurrentstateKey != Enum_AppliStateKey.MenuCredit)
                        {
                            manager.OnClickCreditButton();

                            Debug.Log("Credit button clicked");
                        }

                        break;
                    case Enum_ButtonType.QuitGame:
                        if (Input.GetKeyUp(KeyCode.Mouse0) && !b_quit)
                        {
                            manager.OnClickQuitButton();
                            b_quit = true;

                            Debug.Log("Quit button clicked");
                        }

                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    //just for test 
                    //SceneManager.LoadSceneAsync("Yohan");
                }
            }
        }


    }
}
