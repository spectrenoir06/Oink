using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

    public float f_speed = 0f;

    private bool b_showCredits = false;
    private Vector3 v3_posInit = new Vector3();

    public void showCredits(bool bo) { b_showCredits = bo; }
    public bool isShowingCredit() { return b_showCredits; }

    // Use this for initialization
    void Start () {
        v3_posInit = transform.position;

        //get the bottom of the screen and set the text at the bottom
        float y = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y;
        v3_posInit.y = y;

        transform.position = new Vector3(transform.position.x, y, transform.position.z);
	}

	// Update is called once per frame
	void Update () {

        if (b_showCredits)
            transform.Translate(new Vector3(0, f_speed * Time.deltaTime, 0));
    }

    public void resetCredits()
    {
        transform.position = v3_posInit;
    }
}
