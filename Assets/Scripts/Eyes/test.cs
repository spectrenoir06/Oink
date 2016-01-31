using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    private Vector3 v3_mousePos = Vector3.zero;
    private Vector3 v3_lookTarget = Vector3.zero;

 // Use this for initialization
 void Start () {
  
 }
 
 // Update is called once per frame
 void Update () {
        /*
        v3_mousePos = Input.mousePosition;
        v3_mousePos = new Vector3(v3_mousePos.x, v3_mousePos.y, -10);
        */

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            v3_lookTarget = hit.point;
        }
        transform.LookAt(v3_lookTarget);
    }
}