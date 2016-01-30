using UnityEngine;
using System.Collections;

public class FishManager : MonoBehaviour
{
    private static FishManager instance;

    private FishManager() { }

    public static FishManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new FishManager();
            }
            return instance;
        }
    }

    public Vector3 getClosestFishPosition(Vector3 origin)
    {
        return origin;
    }
}
