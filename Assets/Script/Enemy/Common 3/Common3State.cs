using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common3State : EnemyState
{
    protected Common3 common3 = EnemyManager.instance.common3;
    public override void Enter()
    {
        base.Enter();
        stateMachine = common3.stateMachine;
        common3.anim.Play(animName);
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
