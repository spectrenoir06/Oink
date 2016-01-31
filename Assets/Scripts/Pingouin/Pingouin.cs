using UnityEngine;
using System.Collections;

public class Pingouin : MonoBehaviour
{
    [SerializeField]
    private PingouinNavigation navigation;

    [SerializeField]
    private PinguinAnimator animator;

    [SerializeField]
    private NPCAIController iaController;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] audioClips = new AudioClip[2];

    [SerializeField]
    private GameObject marker;

    private bool currentMark;

    private GameObject banquise;

    private bool isOnBorder;
    // Use this for initialization
    void Start ()
    {
        isOnBorder = true;
        currentMark = false;
        marker.SetActive(currentMark);
        banquise = GameObject.FindGameObjectWithTag("Banquise");

        audioSource.clip = audioClips[0];

        StartCoroutine(playOink());
    }

    int songId = 1;
    IEnumerator playOink()
    {
        while(true)
        {
            audioSource.clip = audioClips[songId^= songId];
            yield return new WaitForSeconds(Random.Range(1,50));
            audioSource.Play();
        }
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, banquise.transform.position) > 12)
        {
            if (!isOnBorder)
            {
                iaController.onBorderBanquise();
            }
            isOnBorder = true;
        }
        else
            isOnBorder = false;

        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit) && hit.transform == transform)
        {
            throwFish(false);
        }

        if (Input.GetMouseButtonDown(1) && Physics.Raycast(ray, out hit) && hit.transform == transform)
        {
            currentMark = !currentMark;
            marker.SetActive(currentMark);
        }
    }

    public void throwFish(bool isTerrorist)
    {
        animator.playAnimation(PinguinAnimator.newStateAnimationPinguin.Throw);
        FishManager.Instance.createPrefabAtPosition(transform.position + new Vector3(0, 1,0), false);
    }}
