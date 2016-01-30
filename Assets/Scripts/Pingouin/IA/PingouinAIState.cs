using UnityEngine;
using System.Collections;

public class PingouinAIState : NPCAIState
{
    PingouinNavigation navigation;

    public PingouinAIState(NPCAIController controller, Transform transform, LuaEnvironnement luaEnvironnement, TextAsset script):
        base(controller, transform, luaEnvironnement, script)
    {
        navigation = transform.GetComponent<PingouinNavigation>();
    }

    public void goToClosestFish()
    {
        Vector3 goal = FishManager.Instance.getClosestFishPosition(transform.position);
        navigation.setGoalPosition(goal);
        navigation.setWalkingState(true);
    }

    public void leaveAndWiggle()
    {
        
    }

    public void leave()
    {

    }

	public void wait(float time){
		//StartCoroutine(waitCoroutine(time));
	}

	private IEnumerable waitCoroutine(float time)
	{
		yield return new WaitForSeconds(time);
		notifyEndWait();
	}


    public void jump()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Banquise").transform);
        navigation.jump();
    }

	public void notifyEndWait()
	{
		lua.call("onWaitEnd", this);
	}

    public void notifytouchGround()
    {
        lua.call("onTouchGround", this);
    }

    public void stopWalking()
    {
        navigation.setWalkingState(false);
    }

    public void startWalking()
    {
        navigation.setWalkingState(true);
    }
}
