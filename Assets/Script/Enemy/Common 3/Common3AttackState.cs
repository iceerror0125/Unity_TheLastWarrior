using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Common3AttackState : EnemyAttackState
{
    private Common3 common3;
    public Common3AttackState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        common3 = (Common3)enemy;
        common3.InstantiateProjectile().GetComponent<Common3ProjectileSetUp>().Activate();
    }

    public override void Exit()
    {
        base.Exit();
        //common3.SetToAttackStateTimer(common3.ToAttackStateCountdown);
    }

    public override void Update()
    {
        base.Update();
    }
}
