using UnityEngine;
using System.Collections;

public class PingouinNavigation : MonoBehaviour
{
    [SerializeField]
    private float speed;

    bool walking;

    private void Awake()
    {
        walking = false;
    }

    public void setGoalPosition(Vector3 goal)
    {
        transform.LookAt(goal);
    }

    public void setWalkingState(bool isWalking)
    {
        walking = isWalking;
    }

    private void Update()
    {
        if(walking)
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
