using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {

    private bool isDangerous = false;

    private GameObject prefab;

    private GameObject explosion;

    public bool IsDangerous
    {
        get
        {
            return isDangerous;
        }

        set
        {
            isDangerous = value;
        }
    }



    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void eat(PingouinAIState pingouinAIState)
    {
        /*if (IsDangerous)
        {
            pingouinAIState.die();
            explose();
        }*/
        FishManager.Instance.destroyFish(this);
    }

    private void explose()
    {
        prefab = Resources.Load("Explosion") as GameObject;
        explosion = Instantiate(prefab) as GameObject;
        explosion.GetComponent<ParticleSystem>().Stop();
        explosion.transform.SetParent(transform, true);
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
