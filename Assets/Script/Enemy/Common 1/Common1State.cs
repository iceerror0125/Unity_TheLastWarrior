using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common1State : EnemyState
{
    protected Common1 common1 = EnemyManager.instance.common1;
    public override void Enter()
    {
        base.Enter();
        stateMachine = common1.stateMachine;
        common1.anim.Play(animName);    
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
