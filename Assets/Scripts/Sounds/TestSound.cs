using UnityEngine;
using System.Collections;

public class TestSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SoundsManager.Instance.playMusic("Frozen Pinguin loop", transform, 1, 1);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
