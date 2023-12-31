using UnityEngine;

public class BaseState
{
    protected StateMachine stateMachine;
    protected string animName;
    protected float timer;

    public BaseState(string animName)
    {
        this.animName = animName;
    }

    public virtual void Enter() { }
    public virtual void Update()
    {
        timer -= Time.deltaTime;
    }
    public virtual void Exit() { }
}
