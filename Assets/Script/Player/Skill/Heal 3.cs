
public class Heal3 : PlayerSkill
{
    protected override void SetUp()
    {
        base.SetUp();
        if (player.IsDead)
        {
            float recoverHP = player.stat.MaxHp * 0.5f;
            player.stat.RecoverHP(recoverHP);
        }
    }
}
