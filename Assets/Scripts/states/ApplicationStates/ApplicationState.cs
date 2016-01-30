﻿using UnityEngine;
using System.Collections;

public abstract class ApplicationState : MonoBehaviour, State
{
    public virtual void update()
    {

    }

    public virtual void fixedUpdate()
    {
       
    }

    public virtual void enterState(State previousState)
    {

    }

    public virtual void leaveState()
    {

    }
}
