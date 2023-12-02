using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    protected StateMachine stateMachine;
    protected string animName;
    protected float timer;
    public virtual void Enter() {}
    public virtual void Update() {
        timer -= Time.deltaTime;
    }
    public virtual void Exit() {}

  
}
