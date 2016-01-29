using UnityEngine;
using System.Collections;

public enum GameState
{
    Menu,
    Game
}

public class GameStateMachine : StateMachine<GameState, AbstractGameState>
{
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
