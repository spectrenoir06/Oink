using UnityEngine;
using System.Collections;

public class AutoIntensity : MonoBehaviour
{
  [SerializeField]
  private Gradient nightDayColor;

  [SerializeField]
  private float maxIntensity = 3f;
  [SerializeField]
  private float minIntensity = 0f;
  [SerializeField]
  private float minPoint = -0.2f;

  [SerializeField]
  private float maxAmbient = 1f;
  [SerializeField]
  private float minAmbient = 0f;
  [SerializeField]
  private float minAmbientPoint = -0.2f;


  [SerializeField]
  private Gradient nightDayFogColor;
  [SerializeField]
  private AnimationCurve fogDensityCurve;
  [SerializeField]
  private float fogScale = 1f;

  [SerializeField]
  private float dayAtmosphereThickness = 0.4f;
  [SerializeField]
  private float nightAtmosphereThickness = 0.87f;

  [SerializeField]
  private Vector3 dayRotateSpeed;
  [SerializeField]
  private Vector3 nightRotateSpeed;

  [SerializeField]
  private Transform stars;
  [SerializeField]
  private Light mainLight;

  private float skySpeed = 1;


  private Skybox sky;
  private Material skyMat;

  private bool isNight = false;

  public bool IsNight
  {
    get
    {
      return isNight;
    }

    private set
    {
      isNight = value;
      EventManager<bool>.Raise(EnumEvent.IsNight, IsNight);
    }
  }

  void Start()
  {
    skyMat = RenderSettings.skybox;
  }

  void Update()
  {
    float tRange = 1 - minPoint;
    float dot = Mathf.Clamp01((Vector3.Dot(mainLight.transform.forward, Vector3.down) - minPoint) / tRange);
    float i = ((maxIntensity - minIntensity) * dot) + minIntensity;

    mainLight.intensity = i;

    if (IsNight && i > 0)
    {
      IsNight = false;
    }
    else if (!IsNight && i == 0)
    {
      IsNight = true;
    }

    tRange = 1 - minAmbientPoint;
    dot = Mathf.Clamp01((Vector3.Dot(mainLight.transform.forward, Vector3.down) - minAmbientPoint) / tRange);
    i = ((maxAmbient - minAmbient) * dot) + minAmbient;
    RenderSettings.ambientIntensity = i;

    mainLight.color = nightDayColor.Evaluate(dot);
    RenderSettings.ambientLight = mainLight.color;

    RenderSettings.fogColor = nightDayFogColor.Evaluate(dot);
    RenderSettings.fogDensity = fogDensityCurve.Evaluate(dot) * fogScale;

    i = ((dayAtmosphereThickness - nightAtmosphereThickness) * dot) + nightAtmosphereThickness;
    skyMat.SetFloat("_AtmosphereThickness", i);

    if (dot > 0)
      stars.Rotate(dayRotateSpeed * Time.deltaTime * skySpeed);
    else
      stars.Rotate(nightRotateSpeed * Time.deltaTime * skySpeed);

#if UNITY_EDITOR
    if (Input.GetKeyDown(KeyCode.Q)) skySpeed *= 0.5f;
    if (Input.GetKeyDown(KeyCode.E)) skySpeed *= 2f;
#endif

  }
}