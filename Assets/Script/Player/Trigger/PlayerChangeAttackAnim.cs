using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeAttackAnim
{
    public void ChangeAttackAnim()
    {
        Player player = PlayerManager.instance.player;
        player.SetIsFirstAttack(!player.IsFirstAttack());
        player.stateMachine.ChangeState(player.idleState);
    }
}
