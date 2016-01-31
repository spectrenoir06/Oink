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

    private GameObject terrorist;

	// Use this for initialization
	void Start ()
    {
        pingouinPrefab = Resources.Load("pinguin") as GameObject;
        StartCoroutine(initLevel());
    }

    public void spawnPinguin(bool isTerrorist = false)
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
        int terroristId = Random.Range(0, maxPinguin);
        while(maxPinguin - count > 0)
        {
            float delay = Random.Range(0.1f, 0.5f);
            yield return new WaitForSeconds(delay);
            pickSpawnPosition((count == terroristId));
            count++;
        }
        if (!terrorist)
            pickSpawnPosition(true);

        terrorist.GetComponent<NPCAIController>().Activated = true;
    }

    public void createPrefabAtPosition(Vector3 position, bool isTerrorist)
    { 
        GameObject go = Instantiate(pingouinPrefab, position, Quaternion.identity) as GameObject;
        NPCAIController ia = go.GetComponent<NPCAIController>();

        if(isTerrorist)
        {
            Debug.Log("SPAWNING TERRORIST");
            ia.init(false, false, false);
            terrorist = go;
        }
        else
        {
            float rand = Random.Range(0.0f, 1.0f);
            if (rand >= 0.5f)
            {
                ia.init(false, true, true);
            }
            else
            {
                ia.init(true, false, true);
            }
        }
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
