using System.Collections;
using UnityEngine;

public class Buff1 : PlayerSkill
{
    [Header("Buff 1")]
    [SerializeField] private float newCountdown;
    [SerializeField] private float originCountdown;
    protected override void SetUp()
    {
        base.SetUp();

        originCountdown = player.AttackCountDown;
        newCountdown = player.AttackCountDown - player.AttackCountDown * 1f; // 100%
        player.SetAttackCountdown(newCountdown);
    }
    protected override void Exit()
    {
        base.Exit();
        player.SetAttackCountdown(originCountdown);
    }
    protected override void ToExitCodition()
    {
        StartCoroutine(ChangeToExit());
    }
    private IEnumerator ChangeToExit()
    {
        yield return new WaitForSeconds(duration);
        base.ToExitCodition();
    }
}
