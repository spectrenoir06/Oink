using UnityEngine;
using System.Collections;

public class Pingouin : MonoBehaviour
{
    [SerializeField]
    private PingouinNavigation navigation;

	// Use this for initialization
	void Start ()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Banquise").transform);
    }

    void OnMouseDown()
    {
        navigation.jump();
    }
}
