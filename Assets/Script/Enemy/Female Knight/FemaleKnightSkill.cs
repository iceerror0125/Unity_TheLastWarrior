using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleKnightSkill : EnemyState
{
    FemaleKnight fk;
    public FemaleKnightSkill(Enemy enemy, string animName) : base(enemy, animName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        fk = (FemaleKnight)enemy;
        fk.InstantiateProjectile().GetComponent<FemaleKnightProjectileSetUp>().Activate(fk);
        timer = 0.5f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (timer <  0)
        {
            stateMachine.ChangeState(fk.battleState);
        }
    }
}
