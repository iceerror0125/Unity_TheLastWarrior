
public class Heal2 : PlayerSkill
{
    private bool hit;
    public void HitEnemy() => hit = true;
    protected override void SetUp()
    {
        base.SetUp();
        if (!hit)
            return;

        float recoverHP = player.stat.MaxHp * 0.05f;
        player.RecoverHP(recoverHP);
    }
    protected override void Exit()
    {
        base.Exit();
        hit = false;
    }
}
