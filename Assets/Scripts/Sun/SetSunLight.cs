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
  private Renderer water;

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
    stars.transform.rotation = transform.rotation;

    Vector3 tvec = Camera.main.transform.position;
    worldProbe.transform.position = tvec;

    water.material.mainTextureOffset = new Vector2(Time.time / 100, 0);
    water.material.SetTextureOffset("_DetailAlbedoMap", new Vector2(0, Time.time / 80));

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