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
		float dist = Vector3.Distance(goal, transform.position);
		Fish tmp = FishManager.Instance.getClosestFish(transform.position);
		if (tmp != null && dist < 1)
		{
			Debug.Log (tmp);
			tmp.eat();
		}
		// Debug.Log (dist);
    }

    public void leaveAndWiggle()
    {
        
    }

    public void leave()
    {

    }

	public void wait(float time, string functioName){
        CoroutineManager.Instance.startCoroutine(waitCoroutine(time, functioName));
	}

	private IEnumerator waitCoroutine(float time, string functioName)
	{
		yield return new WaitForSeconds(time);
        lua.call(functioName, this);
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

    public void throwFish()
    {
        controller.throwFish();
    }

    public float random(float a, float b)
    {
        return Random.Range(a, b);
    }

    public void onFindFish(int count)
    {
        lua.call("onFindFish", this, count);
    }
}
