using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class ButtonCredits : MonoBehaviour
{
    [SerializeField]
    private Credits credits;
    [SerializeField]
    private GameObject button;

    [SerializeField]
    private AudioClip clip;
    private AudioSource audioSource;

    private Ray ray;
    RaycastHit[] hits;

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = clip;
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hits = Physics.RaycastAll(ray, 100);

        for (int i = 0; i < hits.Length; ++i)
        {
            if (hits[i].transform == gameObject.transform)
            {
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    button.SetActive(true);
                    credits.gameObject.SetActive(true);
                    Camera.main.gameObject.GetComponent<BlurOptimized>().enabled = true;
                    credits.showCredits(true);
                }
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    //just for test 
                    //SceneManager.LoadSceneAsync("Yohan");
                }
            }
        }


    }
}
