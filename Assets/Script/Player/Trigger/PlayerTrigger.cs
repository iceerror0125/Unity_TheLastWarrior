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
        player = PlayerManager.instance.player;
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
    public void ExitRollTrigger()
    {
        player.SetIsRolling(false);
    }
    public void FootStep()
    {
        AudioManager.instance.player.FootStep();
    }
    public void Attack()
    {
        AudioManager.instance.player.Attack();
    }
    public void Dead()
    {
        AudioManager.instance.player.Dead();
    }
    public void Scroll()
    {
        AudioManager.instance.player.Scroll();
    }
    public void Jump()
    {
        AudioManager.instance.player.Jump();
    }
    public void Hit()
    {
        AudioManager.instance.player.Hit();
    }
}
