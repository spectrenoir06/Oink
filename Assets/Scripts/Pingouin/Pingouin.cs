using UnityEngine;
using System.Collections;

public class Pingouin : MonoBehaviour
{
  // Use this for initialization
  void Start()
  {
    transform.LookAt(GameObject.FindGameObjectWithTag("Banquise").transform);
    FishManager.Instance.createPrefabAtPostion(transform.position);
  }

  // Update is called once per frame
  void Update()
  {

  }
}
