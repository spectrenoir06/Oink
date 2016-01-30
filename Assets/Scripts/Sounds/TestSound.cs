using UnityEngine;
using System.Collections;

public class TestSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var source = SoundsManager.Instance.playMusic("Frozen Pinguin loop", transform, 0, 1);
        SoundsManager.Instance.fadeIn(source);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
