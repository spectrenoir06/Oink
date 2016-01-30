using UnityEngine;
using System.Collections;

public class Pingouin : MonoBehaviour
{
    [SerializeField]
    private PingouinNavigation navigation;

    [SerializeField]
    private PinguinAnimator animator;

    // Use this for initialization
    void Start ()
    {
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
    void OnMouseDown()
    {
        //navigation.jump();
		throwFish();
    }

    void throwFish()
    {
        animator.playAnimation(PinguinAnimator.newStateAnimationPinguin.Throw);
        FishManager.Instance.createPrefabAtPosition(transform.position);
    }}
