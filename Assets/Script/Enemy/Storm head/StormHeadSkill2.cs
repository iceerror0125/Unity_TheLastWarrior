using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormHeadSkill2 : EnemyState
{
    StormHead sh;

    public StormHeadSkill2(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        sh = (StormHead)enemy;
        sh.InstantiateProjectile2().GetComponent<StormHeadSkill2SetUp>().Activate(sh);

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
