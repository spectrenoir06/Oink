using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {

    [SerializeField]
    private AudioClip explosionAudio;

    private bool isDangerous = false;

    private GameObject prefab;

    private GameObject explosion;
    
    private bool availableForPickup;

    public bool AvailableForPickup
    {
        get { return availableForPickup; }
        set { availableForPickup = value; }
    }
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

    void Awake()
    {
        AvailableForPickup = true;
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

    public bool eat(PingouinAIState pingouinAIState)
    {
        if (IsDangerous)
        {
            deadPingouin = pingouinAIState;
            explose();
            return false;
        }
        else
            FishManager.Instance.destroyFish(this);
        return true;
    }

    private void explose()
    {
        prefab = Resources.Load("Explosion") as GameObject;
        explosion = Instantiate(prefab) as GameObject;
        explosion.transform.position = transform.position;
        explosion.GetComponent<ParticleSystem>().Play();
        explosion.AddComponent<AudioSource>();
        explosion.GetComponent<AudioSource>().clip = explosionAudio;
        explosion.GetComponent<AudioSource>().Play();
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
