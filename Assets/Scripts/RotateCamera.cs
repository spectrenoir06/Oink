using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour {

    [SerializeField]
    private int speed = 5;

    [SerializeField]
    private int border = 50;

    // Update is called once per frame
    void Update () {
        if (Input.mousePosition.x > Screen.width - border)
            gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.eulerAngles - Vector3.up * speed);
        else if (Input.mousePosition.x < border)
            gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.eulerAngles + Vector3.up * speed);
    }
}
