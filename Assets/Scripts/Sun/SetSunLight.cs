using UnityEngine;
using System.Collections;

public class SetSunLight : MonoBehaviour
{

  [SerializeField]
  private Transform sun;

  [SerializeField]
  private AudioSource screamingSound;

  [SerializeField]
  private Transform mainCamera;

  [SerializeField]
  private Transform stars;

  [SerializeField]
  private Transform worldProbe;

  private float volMax = 0.2f;

  // Use this for initialization
  void Start()
  {
    screamingSound.Play();
  }

  // Update is called once per frame
  void Update()
  {
    sun.LookAt(mainCamera);
    controlVolumeScreaming();

    Vector3 tvec = Camera.main.transform.position;
    worldProbe.transform.position = tvec;

  }

  void controlVolumeScreaming()
  {
    if (sun.position.y > -volMax / 2 * 1000 && sun.position.y < volMax / 2 * 1000)
      screamingSound.volume = (sun.position.y + 100) / 1000;
    else if (sun.position.y > volMax / 2 * 1000)
      screamingSound.volume = volMax;
    else
      screamingSound.volume = 0;
  }
}