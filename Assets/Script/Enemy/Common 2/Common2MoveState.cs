using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Common2MoveState : Common2State
{

    public Common2MoveState(string _animName)
    {
        animName = _animName;
    }
    public override void Enter()
    {
        base.Enter();
        timer = common2.MovingTime;
       
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        common2.ChangeVelocity(common2.MoveSpeed() * common2.EntityDir(), common2.rb.velocity.y);
        if (timer < 0) 
        {
            common2.Flip();
            timer = common2.MovingTime;
        }
    }
}
