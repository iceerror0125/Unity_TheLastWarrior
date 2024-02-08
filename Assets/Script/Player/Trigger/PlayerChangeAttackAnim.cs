
public class PlayerChangeAttackAnim
{
    public void ActiveTrigger()
    {
        var player = PlayerManager.instance.player;
        player.SetIsFirstAttack(!player.IsFirstAttack);
        if (player.IsGround)
        {
            player.stateMachine.ChangeState(player.idleState);
        }
        else
        {
            player.stateMachine.ChangeState(player.fallState);
        }
    }
}
