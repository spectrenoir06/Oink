using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitreManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            SceneManager.LoadSceneAsync("Yohan 2");
        }
	}
}
