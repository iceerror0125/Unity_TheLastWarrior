using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollToIdleTrigger
{
    public void ActiveTrigger()
    {
        var player = PlayerManager.instance.player;
        player.stateMachine.ChangeState(player.idleState);
    }
}
