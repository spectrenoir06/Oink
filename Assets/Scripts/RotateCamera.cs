using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour {

    [SerializeField]
    private int maxSpeed = 5;

    [SerializeField]
    private int border = 50;

    // Update is called once per frame
    void Update () {
        float speed = 0;
        if (Input.mousePosition.x > Screen.width - border)
            speed = (Screen.width - border - Input.mousePosition.x) / (border) * maxSpeed;
        else if (Input.mousePosition.x < border)
            speed = (border - Input.mousePosition.x) / (border) * maxSpeed;

        gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.eulerAngles + Vector3.up * speed);

    }
}
