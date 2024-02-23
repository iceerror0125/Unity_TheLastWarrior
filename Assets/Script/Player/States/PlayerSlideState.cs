using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlideState : PlayerState
{
    Vector2 middleVector;
    public PlayerSlideState(string animName) : base(animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Vector2 VectorA = new Vector2(5f, 0f);
        Vector2 VectorB = new Vector2(0f, -6f);

        middleVector = (VectorA * player.MoveDir + VectorB) / 2f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        player.ChangeVelocity(middleVector);
    }
}
