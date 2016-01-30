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

    public void stopWalking()
    {
        navigation.setWalkingState(false);
    }

    public void startWalking()
    {
        navigation.setWalkingState(true);
    }
}
