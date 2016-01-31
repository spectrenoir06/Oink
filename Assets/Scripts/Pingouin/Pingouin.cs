using UnityEngine;
using System.Collections;

public class Pingouin : MonoBehaviour
{
    [SerializeField]
    private PingouinNavigation navigation;

    [SerializeField]
    private PinguinAnimator animator;

    [SerializeField]
    private GameObject marker;

    private bool currentMark;

    // Use this for initialization
    void Start ()
    {
        currentMark = false;
        marker.SetActive(currentMark);
        //transform.LookAt(GameObject.FindGameObjectWithTag("Banquise").transform, Vector3.right);
        //StartCoroutine(popFish());
    }
    
    IEnumerator popFish()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            throwFish();
        }
    }

    void Update()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit) && hit.transform == transform)
        {
            throwFish();
        }

        if (Input.GetMouseButtonDown(1) && Physics.Raycast(ray, out hit) && hit.transform == transform)
        {
            currentMark = !currentMark;
            marker.SetActive(currentMark);
        }
    }

    void throwFish()
    {
        animator.playAnimation(PinguinAnimator.newStateAnimationPinguin.Throw);
        FishManager.Instance.createPrefabAtPosition(transform.position);
    }}
