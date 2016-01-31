using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {

    private bool isDangerous = false;

    private GameObject prefab;

    private GameObject explosion;

    private PingouinAIState deadPingouin = null;

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
        if (deadPingouin != null)
        {
            deadPingouin.die();
            FishManager.Instance.destroyFish(this);
        }
    }

    public void eat(PingouinAIState pingouinAIState)
    {
        if (IsDangerous)
        {
            deadPingouin = pingouinAIState;
            explose();
        }
        else
            FishManager.Instance.destroyFish(this);
    }

    private void explose()
    {
        prefab = Resources.Load("Explosion") as GameObject;
        explosion = Instantiate(prefab) as GameObject;
        explosion.transform.position = transform.position;
        explosion.GetComponent<ParticleSystem>().Play();
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
