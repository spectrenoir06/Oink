using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    public float f_Speed = 1f;

    private Vector3 v3_mousePos = Vector3.zero;
    private Vector3 v3_targetDir = Vector3.zero;
    private Vector3 v3_newDir = Vector3.zero;
    private float f_step = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        v3_mousePos = Input.mousePosition;
        v3_targetDir = v3_mousePos - transform.position;
        f_step = f_Speed * Time.deltaTime;

        v3_newDir = Vector3.RotateTowards(transform.forward, v3_targetDir, f_step, 0f);
        Debug.DrawRay(transform.position, v3_newDir, Color.red);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(v3_newDir);
    }
}
