using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common2State : EnemyState
{

    protected Common2 common2 = EnemyManager.instance.common2;
    public override void Enter()
    {
        base.Enter();
        stateMachine = common2.stateMachine;
        common2.anim.Play(animName);
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
