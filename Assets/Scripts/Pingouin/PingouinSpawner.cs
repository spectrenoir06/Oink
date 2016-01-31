using UnityEngine;
using System.Collections;

public class PingouinSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform spawnOrbiter;

    [SerializeField]
    private float waitBeforeSpawn;

    [SerializeField]
    private int maxPinguin;

    private GameObject pingouinPrefab;

	// Use this for initialization
	void Start ()
    {
        pingouinPrefab = Resources.Load("pinguin") as GameObject;
        StartCoroutine(initLevel());
    }

    private void spawnPinguin(bool isTerrorist = false)
    {
        StartCoroutine(spawnCoroutine(isTerrorist));
    }

    private IEnumerator spawnCoroutine(bool isTerrorist)
    {
        yield return new WaitForSeconds(waitBeforeSpawn);
        pickSpawnPosition(isTerrorist);
    }

    private IEnumerator initLevel()
    {
        int count = 0;
        while(maxPinguin - count > 0)
        {
            float delay = Random.Range(0.1f, 0.5f);
            yield return new WaitForSeconds(delay);
            pickSpawnPosition(false);
            count++;
        }
    }

    public void createPrefabAtPosition(Vector3 position, bool isTerrorist)
    { 
        Instantiate(pingouinPrefab, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update () {
	
	}

    void pickSpawnPosition(bool isTerrorist)
    {
        float randRot = Random.Range(0, 360);
        transform.Rotate(new Vector3(0, randRot, 0));
        createPrefabAtPosition(spawnOrbiter.position, isTerrorist);
    }
}
