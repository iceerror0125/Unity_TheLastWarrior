using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    protected Player player;

    [SerializeField] private Buff3 skill;
    [SerializeField] private Heal2 heal;

    private PlayerRollToIdleTrigger toIdleTrigger;
    private PlayerChangeAttackAnim changeAttackAnim;
    private HitEnemyTrigger hitEnemyTrigger;

    void Start()
    {
        toIdleTrigger = new PlayerRollToIdleTrigger();
        changeAttackAnim = new PlayerChangeAttackAnim();   
        hitEnemyTrigger = new HitEnemyTrigger();
    }

    public void RollStateToIdleState()
    {
        toIdleTrigger.ActiveTrigger();
    }
    public void ChangeAttackAnim()
    {
        changeAttackAnim.ActiveTrigger();
    }
    public void HitEnemyTrigger()
    {
        hitEnemyTrigger.ActiveTrigger(skill, heal);
    }
}
