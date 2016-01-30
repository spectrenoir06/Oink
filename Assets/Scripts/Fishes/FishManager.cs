using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FishManager : MonoBehaviour
{
    private static FishManager instance;

    private GameObject fishPrefab;

    private List<Fish> fishList;

    private FishManager()
    {
        fishList = new List<Fish>();
    }

    public static FishManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindGameObjectWithTag("FishManager").GetComponent<FishManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)

            //if not, set instance to this
            instance = this;

        fishPrefab = Resources.Load("fish 1") as GameObject;
        createPrefabAtPostion(transform.position);
    }

    public void createPrefabAtPostion(Vector3 position)
    {
        createPrefabAtPostion(position, Quaternion.identity);
    }

    public void createPrefabAtPostion(Vector3 position, Quaternion rotation)
    {
        GameObject newFish = Instantiate(fishPrefab, position, rotation) as GameObject;
        fishList.Add(newFish.GetComponent<Fish>());
    }

    public Vector3 getClosestFishPosition(Vector3 origin)
    {
        float closestDistance = 99999;
        Fish closestFish = null;
        foreach (Fish f in fishList)
        {
            float distance = Vector3.Distance(f.transform.position, origin);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestFish = f;
            }
        }
        if (closestFish != null)
            return closestFish.transform.position;
        else
            return origin;
    }
}
