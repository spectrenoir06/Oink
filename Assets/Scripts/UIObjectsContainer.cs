using UnityEngine;
using System.Collections;

public class UIObjectsContainer : MonoBehaviour {

    public GameObject go_gameButton;
    public GameObject go_creditButton;
    public GameObject go_quitButton;
    public GameObject go_backButton;
    public GameObject go_creditText;

    private static UIObjectsContainer instance = null;

    public static UIObjectsContainer getInstance()
    {
        if (instance == null)
        {
            GameObject objet = GameObject.Find("UIObjectsContainer");
            if (objet == null)
            {
                Debug.LogError("ERROR: there is no UIObjectsContainer in this scene");
                return null;
            }

            instance = objet.GetComponent<UIObjectsContainer>();
        }

        return instance;
    }

	// Use this for initialization
	void Start () {
	
	}

}
