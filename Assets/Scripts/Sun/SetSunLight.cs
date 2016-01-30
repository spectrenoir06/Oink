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

  Material sky;

  [SerializeField]
  private Renderer water;

  [SerializeField]
  private Transform stars;

  [SerializeField]
  private Transform worldProbe;

  // Use this for initialization
  void Start()
  {

    sky = RenderSettings.skybox;
  }

  // Update is called once per frame
  void Update()
  {
    sun.LookAt(mainCamera);
    if (sun.position.y > -100 && sun.position.y < 100)
      screamingSound.volume = (sun.position.y + 100) / 1000;
    stars.transform.rotation = transform.rotation;

    Vector3 tvec = Camera.main.transform.position;
    worldProbe.transform.position = tvec;

    water.material.mainTextureOffset = new Vector2(Time.time / 100, 0);
    water.material.SetTextureOffset("_DetailAlbedoMap", new Vector2(0, Time.time / 80));

  }
}