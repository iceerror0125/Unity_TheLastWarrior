using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private PlayerRollToIdleTrigger toIdleTrigger;
    private PlayerChangeAttackAnim changeAttackAnim;

    void Start()
    {
        toIdleTrigger = new PlayerRollToIdleTrigger();
        changeAttackAnim = new PlayerChangeAttackAnim();    
    }

    public void RollStateToIdleState()
    {
        toIdleTrigger.RollStateToIdleState();
    }
    public void ChangeAttackAnim()
    {
        changeAttackAnim.ChangeAttackAnim();
    }
}
