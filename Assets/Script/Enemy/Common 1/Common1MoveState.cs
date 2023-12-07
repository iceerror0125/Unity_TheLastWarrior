using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common1MoveState : Common1State
{
    float idleTimer;
    public Common1MoveState(string _animName)
    {
        animName = _animName;
    }
    public override void Enter()
    {
        base.Enter();
        timer = common1.MoveDuration();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        common1.ChangeVelocity(common1.MoveSpeed() * common1.EntityDir(), common1.rb.velocity.y);
        if (timer < 0  || common1.IsWall())
        {
            common1.idleState.SetHasFlip(true);
            stateMachine.ChangeState(common1.idleState);
        }
    }
}
