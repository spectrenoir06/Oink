using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void eat()
    {
        FishManager.Instance.destroyFish(this);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Banquise")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
