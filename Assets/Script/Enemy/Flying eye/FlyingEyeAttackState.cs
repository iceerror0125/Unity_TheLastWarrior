using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeAttackState : EnemyAttackState
{
    private FlyingEye flyingEye;
    private Vector2 playerPos;
    float dir;
    public FlyingEyeAttackState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        flyingEye = (FlyingEye)enemy;

        flyingEye.SetIsApproach(false);
        flyingEye.SetOriginalPosition(flyingEye.transform.position);
        playerPos = PlayerManager.instance.player.transform.position;
        dir = flyingEye.IsOnTheRightOfPlayer() ? -1 : 1;
    }

    public override void Exit()
    {
        base.Exit();
        flyingEye.SetIsApproach(true);
    }

    public override void Update()
    {
        base.Update();

        flyingEye.transform.position = Vector2.MoveTowards(
            flyingEye.transform.position,
            playerPos, 
            flyingEye.AttackSpeed * Time.deltaTime);
    }
}
