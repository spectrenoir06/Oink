using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitreManager : MonoBehaviour {

    [SerializeField]
    private Animator animator;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(waitFadeOut());
        }
	}

    public IEnumerator waitFadeOut()
    {
        animator.SetTrigger("fadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync("Menu main");
    }
}
