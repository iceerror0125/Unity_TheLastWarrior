using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common1IdleState : Common1State
{
    private bool hasFlip;
    public Common1IdleState(string _animName)
    {
        animName = _animName;
    }
    public void SetHasFlip(bool _hasFlip) => hasFlip = _hasFlip;
    private void Flip()
    {
        common1.ChangeRotation();
        common1.SetIsFacingRight(!common1.IsFacingRight());
    }

    public override void Enter()
    {
        base.Enter();
        timer = common1.IdleDuration();
        common1.SetIsDetectedPlayer(false);
    }

    public override void Exit()
    {
        base.Exit();
        hasFlip = false;
    }

    public override void Update()
    {
        base.Update();
        common1.ZeroVelocity();
        if (timer < 0)
        {
            if (hasFlip)
                Flip();
            stateMachine.ChangeState(common1.moveState);
        }
    }
}
