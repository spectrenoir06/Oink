using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public enum Enum_ButtonType
{
    Non,
    PlayGame,
    MenuCredit,
    QuitGame,
    Intro
}

[RequireComponent(typeof(AudioSource))]

public class Button : MonoBehaviour {

    public Enum_ButtonType buttonType = Enum_ButtonType.Non;
    public AudioClip audioclip;

    private AudioSource audioSource;
    private Applicationmanager manager;
    private bool b_quit = false;
    private Ray ray;
    private RaycastHit[] hits;
    private Animator animator;

    // Use this for initialization
    void Start () {
        manager = Applicationmanager.GetInstance();
        animator = gameObject.GetComponentInParent<Animator>();
        animator.SetBool("in", false);

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioclip;
	}
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hits = Physics.RaycastAll(ray, 100);
        bool b_touchButton = false;
        bool b_inButton = false;
        for (int i = 0; i < hits.Length; ++i)
        {
            if (hits[i].transform == gameObject.transform)
            {
                animator.SetBool("in", true);
                b_inButton = true;

                switch (buttonType)
                {
                    case Enum_ButtonType.PlayGame:
                        if (Input.GetKeyUp(KeyCode.Mouse0) && manager.getAppliStateMachine().CurrentstateKey != Enum_AppliStateKey.Game)
                        {
                            GameObject go = GameObject.FindGameObjectWithTag("RulePanel");
                            RulesManager rmgr = go.GetComponent<RulesManager>();
                            rmgr.ruleIn();
                            b_touchButton = true;
                            audioSource.Play();
                            Debug.Log("Play button clicked");
                        }

                        break;
                    case Enum_ButtonType.MenuCredit:
                        if (Input.GetKeyUp(KeyCode.Mouse0) && manager.getAppliStateMachine().CurrentstateKey != Enum_AppliStateKey.MenuCredit)
                        {
                            b_touchButton = true;
                            manager.OnClickCreditButton();
                            audioSource.Play();
                            Debug.Log("Credit button clicked");
                        }

                        break;
                    case Enum_ButtonType.QuitGame:
                        if (Input.GetKeyUp(KeyCode.Mouse0) && !b_quit)
                        {
                            b_touchButton = true;
                            manager.OnClickQuitButton();
                            b_quit = true;
                            audioSource.Play();
                            Debug.Log("Quit button clicked");
                        }

                        break;
                    case Enum_ButtonType.Intro:
                        if (Input.GetKeyUp(KeyCode.Mouse0) && !b_quit)
                        {
                            UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
                        }

                        break;
                    default:
                        break;
                }
            }
        }

        if (!b_inButton)
        {
            animator.SetBool("in", false);

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                //just for test 
                //SceneManager.LoadSceneAsync("Yohan");
            }
        }

        if (b_touchButton)
            animator.SetBool("in", false);
    }
}
