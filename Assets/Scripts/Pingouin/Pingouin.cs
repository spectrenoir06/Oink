using UnityEngine;
using System.Collections;

public class Pingouin : MonoBehaviour
{
    [SerializeField]
    private PingouinNavigation navigation;

    [SerializeField]
    private PinguinAnimator animator;

    // Use this for initialization
    void Start ()
    {
        //transform.LookAt(GameObject.FindGameObjectWithTag("Banquise").transform, Vector3.right);
    }

    void OnMouseDown()
    {
        navigation.jump();
    }
}
