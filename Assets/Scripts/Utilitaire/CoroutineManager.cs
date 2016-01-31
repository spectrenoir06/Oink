using UnityEngine;
using System.Collections;

public class CoroutineManager : MonoBehaviour
{
    private static CoroutineManager instance;

    private CoroutineManager()
    {

    }

    public static CoroutineManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindGameObjectWithTag("CoroutineManager").GetComponent<CoroutineManager>();
            }
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }

    public void startCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
