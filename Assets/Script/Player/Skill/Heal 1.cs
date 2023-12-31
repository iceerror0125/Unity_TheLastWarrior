
public class Heal1 : PlayerSkill
{
    protected override void SetUp()
    {
        base.SetUp();
        float recoverHP = player.stat.MaxHp * 0.2f;
        player.stat.RecoverHP(recoverHP);
    }
}
