using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerWallSlideState : PlayerState
{
    float delayTime;
    bool wasPress;

    public PlayerWallSlideState(string animName) : base(animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.ZeroVelocity();
        player.SetIsSliding(true);
        player.SetIsFacingRight(!player.IsFacingRight);
        player.ZeroJumpCounter();
        //player.PlusJumpCounter();
        player.SetCanHighJump(true);

        wasPress = false;
    }

    public override void Exit()
    {
        base.Exit();
        player.SetIsSliding(false);
        player.ChangeRotation();
    }

    public override void Update()
    {
        base.Update();
        player.ChangeVelocity(new Vector2(player.rb.velocity.x, player.WallSlideGravity));
        if (!IsSlideWall())
        {
            stateMachine.ChangeState(player.fallState);
        }
        CheckToGroundState();
        JumpOutWall();
       
    }

    private void JumpOutWall()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            stateMachine.ChangeState(player.wallJumpState);
        }
    }

    private void CheckToGroundState()
    {
        if (player.IsGround)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
    private bool IsSlideWall()
    {
        Vector2 size = new Vector2(1.243875f, 1.939426f);
        var x = Physics2D.OverlapCapsuleAll(player.transform.position, size, CapsuleDirection2D.Vertical, 0);
        foreach (var collide in x)
        {
            /* TilemapCollider2D tilemapCollider = collide.GetComponent<TilemapCollider2D>();
             Debug.Log(tilemapCollider.gameObject.layer);*/

            if (collide != null)
            {
                //Debug.Log(collide.gameObject.name);
                if (collide.gameObject.layer == 3)
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }


        }

        return false;
    }
}
