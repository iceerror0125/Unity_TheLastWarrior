using System.Collections;
using UnityEngine;

public class Buff3 : PlayerSkill
{
    [SerializeField] private int counter;
    [SerializeField] private bool isActivated;
    private float originalCritDamage;
    private float originalCritRate;

    public bool IsActivated => isActivated;
    protected override void SetUp()
    {
        base.SetUp();
        originalCritDamage = player.stat.CritDamage;
        originalCritRate = player.stat.CritRate;

        float plusCritDamage = player.stat.CritDamage + player.stat.CritDamage * 1.5f; // 150%
        player.stat.SetCritRate(1);
        player.stat.SetCritDamage(plusCritDamage);

        counter = 5;
        isActivated = true;
      
    }
    protected override void Exit()
    {
        counter = 0;
        player.stat.SetCritRate(originalCritRate);
        player.stat.SetCritDamage(originalCritDamage);
        base.Exit();
    }
    public void Trigger()
    {
        counter--;
    }
    protected override void ToExitCodition()
    {
        StartCoroutine(WaitCounter());
    }
    private IEnumerator WaitCounter()
    {
        while (counter > 0)
        {
            yield return null;
        }
        base.ToExitCodition();
    }
}
