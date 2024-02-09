
public class Buff2 : PlayerSkill
{
    private float plusDamage;
    private float oldATK = 0;
    protected override void SetUp()
    {
        // +50% damage
        if (oldATK != player.stat.Damage)
        {
            plusDamage = player.stat.Damage + player.stat.Damage * 0.5f;
            player.stat.SetDamage(plusDamage);
            oldATK = plusDamage;
        }
        
    }
}
