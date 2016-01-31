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
        var lookPos = goal - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = rotation;
    }

    public void setWalkingState(bool isWalking)
    {
        walking = isWalking;
        if (!walking)
            mRigidbody.velocity = Vector3.zero;
    }

    public void jump()
    {
        jumpRequested = true;
        mRigidbody.AddRelativeForce(Vector3.up * 500 + Vector3.forward * 200);
    }

    private void goForward(float fspeed)
    {
        mRigidbody.velocity = new Vector3(transform.forward.x * speed, mRigidbody.velocity.y, transform.forward.z * speed * fspeed);
    }

    public void setSpeed(float f)
    {
        speed = f;
    }

    public void turnAround(float degree)
    {
        transform.RotateAround(transform.position, transform.up, degree);
    }

    public void turnAround()
    {
        turnAround(180);
    }

    public void randomizeDirection()
    {
        float randAngle = Random.Range(10, 360);
        turnAround(randAngle);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Banquise")
        {
            if(jumpRequested)
            {
                jumpRequested = false;
                ia.notifytouchGround();
            }
        }
		if(collision.collider.tag == "Destroy_Zone")
		{
			Debug.Log("20cm de bite");
			Destroy (this.gameObject);
		}
    }

    private void FixedUpdate()
    {
        if (walking)
            goForward(1);
    }
}
