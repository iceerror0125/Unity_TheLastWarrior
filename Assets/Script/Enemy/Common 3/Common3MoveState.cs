using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Common3MoveState : Common3State
{
    public Common3MoveState(string _animName)
    {
        animName = _animName;
    }
    public override void Enter()
    {
        base.Enter();
        timer = common3.MoveDuration();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        common3.ChangeVelocity(common3.MoveSpeed() * common3.EntityDir(), common3.rb.velocity.y);
        if (timer < 0 || common3.IsWall())
        {
            common3.idleState.SetHasFlip(true);
            stateMachine.ChangeState(common3.idleState);
        }
    }
}
