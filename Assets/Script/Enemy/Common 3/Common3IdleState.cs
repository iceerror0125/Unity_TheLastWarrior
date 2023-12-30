using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Common3IdleState : Common3State
{
    private bool hasFlip;
    public Common3IdleState(string _animName)
    {
        animName = _animName;
    }
    public void SetHasFlip(bool _hasFlip) => hasFlip = _hasFlip;
    private void Flip()
    {
        common3.ChangeRotation();
        common3.SetIsFacingRight(!common3.IsFacingRight());
    }

    public override void Enter()
    {
        base.Enter();
        timer = common3.IdleDuration();
        common3.SetIsDetectedPlayer(false);
    }

    public override void Exit()
    {
        base.Exit();
        hasFlip = false;
    }

    public override void Update()
    {
        base.Update();
        common3.ZeroVelocity();
        if (timer < 0)
        {
            if (hasFlip)
                Flip();
            stateMachine.ChangeState(common3.moveState);
        }
    }
}
