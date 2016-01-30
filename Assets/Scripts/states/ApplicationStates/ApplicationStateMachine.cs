using UnityEngine;
using System.Collections;

public enum Enum_AppliStateKey
{
    Game,
    MenuMain,
    MenuCredit
}

public class ApplicationStateMachine : StateMachine<Enum_AppliStateKey, ApplicationState>
{
	// Use this for initialization
	void Start () {
	
	}
}
