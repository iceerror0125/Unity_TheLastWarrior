using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BeeIdleState : BeeState
{
    public BeeIdleState(string _animName)
    {
        animName = _animName;
    }
    private bool hasFlip;
  
    public void SetHasFlip(bool _hasFlip) => hasFlip = _hasFlip;
    private void Flip()
    {
        bee.ChangeRotation();
        bee.SetIsFacingRight(!bee.IsFacingRight());
    }

    public override void Enter()
    {
        base.Enter();
        timer = bee.IdleDuration();
        bee.SetIsDetectedPlayer(false);
    }

    public override void Exit()
    {
        base.Exit();
        hasFlip = false;
    }

    public override void Update()
    {
        base.Update();
        bee.ZeroVelocity();
        if (timer < 0)
        {
            if (hasFlip)
                Flip();
            stateMachine.ChangeState(bee.moveState);
        }
    }
}
