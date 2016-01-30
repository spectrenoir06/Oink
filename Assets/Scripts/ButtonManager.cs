using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {

    public GameObject go_gameButton;
    public GameObject go_creditButton;
    public GameObject go_quitButton;
    public GameObject go_backButton;

    private static ButtonManager instance = null;

    public static ButtonManager getInstance()
    {
        if (instance == null)
        {
            GameObject objet = GameObject.Find("ButtonManager");
            if (objet == null)
            {
                Debug.LogError("ERROR: there is no ButtonManager in this scene");
                return null;
            }

            instance = objet.GetComponent<ButtonManager>();
        }

        return instance;
    }

	// Use this for initialization
	void Start () {
	
	}

}
