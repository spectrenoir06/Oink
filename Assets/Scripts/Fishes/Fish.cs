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
            if (value)
            {
                prefab = Resources.Load("Explosion") as GameObject;
                explosion =  Instantiate(prefab) as GameObject;
                explosion.transform.SetParent(transform);
            }
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
        if (IsDangerous)
        {
            pingouinAIState.die();
            explose();
        }
        FishManager.Instance.destroyFish(this);
    }

    private void explose()
    {
        explosion.GetComponent<ParticleSystem>().Play();
    }
}
