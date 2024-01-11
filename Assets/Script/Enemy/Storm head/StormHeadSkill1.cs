using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormHeadSkill1 : EnemyState
{
    StormHead sh;
    public StormHeadSkill1(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        sh = (StormHead)enemy;
        sh.InstantiateProjectile().GetComponent<StormHeadSkill1SetUp>().Activate(sh);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        stateMachine.ChangeState(sh.battleState);
    }
}
