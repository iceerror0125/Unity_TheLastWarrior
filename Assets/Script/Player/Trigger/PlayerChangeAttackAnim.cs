using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeAttackAnim
{
    public void ActiveTrigger()
    {
        var player = PlayerManager.instance.player;
        player.SetIsFirstAttack(!player.IsFirstAttack());
        player.stateMachine.ChangeState(player.idleState);
    }
}
