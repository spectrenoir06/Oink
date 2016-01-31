using UnityEngine;
using System.Collections;

public class RulesManager : MonoBehaviour {

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

	}
	
    public void ruleIn()
    {
        animator.SetTrigger("rulein");
    }

	// Update is called once per frame
	void Update () {

        /*if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle2"))
            {
                animator.SetBool("in", false);
                animator.SetBool("out", true);
            }
        }  */ 

	}
}
