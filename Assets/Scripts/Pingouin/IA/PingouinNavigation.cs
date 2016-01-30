using UnityEngine;
using System.Collections;

public class PingouinNavigation : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody mRigidbody;
    private bool jumpRequested;

    bool walking;

    private void Awake()
    {
        jumpRequested = false;
        walking = false;
        mRigidbody = GetComponent<Rigidbody>();
    }

    public void setGoalPosition(Vector3 goal)
    {
        transform.LookAt(goal);
    }

    public void setWalkingState(bool isWalking)
    {
        walking = isWalking;
    }

    public void jump()
    {
        jumpRequested = true;
    }

    private void FixedUpdate()
    {
        if (walking)
            mRigidbody.velocity = new Vector3(transform.forward.x * speed, mRigidbody.velocity.y, transform.forward.z * speed);

        if (jumpRequested)
        {
            mRigidbody.AddForce(Vector3.up * 500);
            jumpRequested = false;
        }
    }
}
