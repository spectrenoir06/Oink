using UnityEngine;
using System.Collections;

public class PingouinNavigation : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField] 
    private NPCAIController ia;

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
        mRigidbody.AddRelativeForce(Vector3.up * 500 + Vector3.forward * 200);
    }

    private void goForward(float fspeed)
    {
        mRigidbody.velocity = new Vector3(transform.forward.x * speed, mRigidbody.velocity.y, transform.forward.z * speed * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Banquise")
        {
            jumpRequested = false;
            ia.notifytouchGround();
        }
    }

    private void FixedUpdate()
    {
        if (walking)
            goForward(1);
    }
}
