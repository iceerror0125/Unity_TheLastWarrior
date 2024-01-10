using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeathSkill1 : EnemyState
{
    BringerOfDeath bod;
    public BringerOfDeathSkill1(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        bod = (BringerOfDeath)enemy;

        bod.SetIsAttack(true);
        bod.InstantiateProjectile().GetComponent<BringerOfDeathProjectileSetUp>().Activate(bod);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (!bod.IsAttack)
        {
            stateMachine.ChangeState(bod.battleState);
        }
    }

   
}
