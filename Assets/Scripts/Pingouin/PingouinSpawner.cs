using UnityEngine;
using System.Collections;

public class PingouinSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform spawnOrbiter;

    private GameObject pingouinPrefab;

	// Use this for initialization
	void Start ()
    {
        pingouinPrefab = Resources.Load("pinguin") as GameObject;
        StartCoroutine(testRot());
    }

    private IEnumerator testRot()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            pickSpawnPosition();
        }
    }

    public void createPrefabAtPosition(Vector3 position)
    { 
        Debug.Log(position);
        GameObject newFish = Instantiate(pingouinPrefab) as GameObject;
        newFish.transform.position = position;
    }

    // Update is called once per frame
    void Update () {
	
	}

    void pickSpawnPosition()
    {
        float randRot = Random.Range(0, 360);
        transform.Rotate(new Vector3(0, randRot, 0));
        createPrefabAtPosition(spawnOrbiter.position);
    }
}
