using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    protected Player player;

    [SerializeField] private Buff3 skill;
    [SerializeField] private Heal2 heal;

    private PlayerRollToIdleTrigger toIdleTrigger;
    private PlayerChangeAttackAnim changeAttackAnim;
    private HitTrigger hitEnemyTrigger;

    void Start()
    {
        toIdleTrigger = new PlayerRollToIdleTrigger();
        changeAttackAnim = new PlayerChangeAttackAnim();   
        hitEnemyTrigger = new HitTrigger();
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
