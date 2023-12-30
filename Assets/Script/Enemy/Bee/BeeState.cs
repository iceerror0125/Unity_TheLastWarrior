using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeState : EnemyState
{
    protected Bee bee = EnemyManager.instance.bee;
    public override void Enter()
    {
        base.Enter();
        stateMachine = bee.stateMachine;
        bee.anim.Play(animName);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
