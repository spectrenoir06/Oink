using UnityEngine;
using System.Collections;

public class PingouinAIState : NPCAIState
{
    PingouinNavigation navigation;

    private int fishEaten = 0;

    public PingouinAIState(NPCAIController controller, Transform transform, LuaEnvironnement luaEnvironnement, TextAsset script):
        base(controller, transform, luaEnvironnement, script)
    {
        navigation = transform.GetComponent<PingouinNavigation>();
    }

    public int getFishCount()
    {
        return fishEaten;
    }

    public void incrementFishCount()
    {
        fishEaten++;
    }

    public void goToClosestFish()
    {
        Vector3 goal = FishManager.Instance.getClosestFishPosition(transform.position);
        navigation.setGoalPosition(goal);
		float dist = Vector3.Distance(goal, transform.position);
		Fish tmp = FishManager.Instance.getClosestFish(transform.position);
		if (tmp != null && dist < 1)
		{
            onFindFish(tmp);
        }
    }

    public void turnAround()
    {
        navigation.turnAround();
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
        var lookPos = GameObject.FindGameObjectWithTag("Banquise").transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = rotation;
        navigation.jump();
        /*transform.LookAt(GameObject.FindGameObjectWithTag("Banquise").transform, transform.up);
        navigation.jump();
        transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);*/
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

    public void onFindFish(Fish f)
    {
        lua.call("onFindFish", this, f);
    }

    public void onAnimEnd()
    {
        lua.call("onAnimEnd", this);
    }

    public void playAnimation(string name)
    {
        controller.playAnimation(name);
    }

    public void die()
    {

    }

    public void onBorderBanquise()
    {
        lua.call("onBorderBanquise", this);
    }

    public void randomizeDirection()
    {
        navigation.randomizeDirection();
    }
    
    public void setSpeed(float f)
    {
        navigation.setSpeed(f);
    }
}
