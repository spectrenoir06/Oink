using UnityEngine;
using System.Collections;

public class PinguinAnimator : MonoBehaviour {
  private enum StateAnimationPinguin
  {
    Walk,
    Throw,
    Dive,
    Eat,
    DanceThenDive,
    DanceThenEat
  }

  public enum newStateAnimationPinguin
  {
    Throw,
    Dive,
    Eat,
    DanceThenDive,
    DanceThenEat
  }

  [SerializeField]
  private NPCAIController iaController;

  [SerializeField]
  private Animator animator;

  private StateAnimationPinguin currentState;

  // Use this for initialization
  void Start () {
    currentState = StateAnimationPinguin.Walk;
  }
	
	// Update is called once per frame
	void Update () {
  }

  public void playAnimation(newStateAnimationPinguin state)
  {
    switch (state)
    {
      case newStateAnimationPinguin.Throw:
        animator.SetTrigger("Throw");
        currentState = StateAnimationPinguin.Throw;
        break;
      case newStateAnimationPinguin.Dive:
        animator.SetTrigger("Dive");
        currentState = StateAnimationPinguin.Dive;
        break;
      case newStateAnimationPinguin.Eat:
        animator.SetTrigger("Eat");
        currentState = StateAnimationPinguin.Eat;
        break;
      case newStateAnimationPinguin.DanceThenDive:
        animator.SetTrigger("DiveAfterDance");
        animator.SetTrigger("Dance");
        currentState = StateAnimationPinguin.DanceThenDive;
        break;
      case newStateAnimationPinguin.DanceThenEat:
        animator.SetTrigger("EatAfterDance");
        animator.SetTrigger("Dance");
        currentState = StateAnimationPinguin.DanceThenEat;
        break;
    }
  }

  public void Destroy()
  {
    Destroy(transform.parent.parent.gameObject);
  }

  public void OnStartWalk()
  {
    if (currentState != StateAnimationPinguin.Walk)
    {
      iaController.startWalking();
      currentState = StateAnimationPinguin.Walk;
    }
  }
}
