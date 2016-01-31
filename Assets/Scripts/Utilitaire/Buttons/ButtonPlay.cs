using UnityEngine;
using System.Collections;

public class ButtonPlay : MonoBehaviour
{

    [SerializeField]
    private RulesManager rulesMgr;

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
                    rulesMgr.ruleIn();
                    audioSource.Play();
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
