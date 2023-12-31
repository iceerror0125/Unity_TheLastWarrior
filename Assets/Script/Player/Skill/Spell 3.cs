using System.Collections;
using UnityEngine;

public class Spell3 : PlayerSkill
{
    [SerializeField] private GameObject skillPrefab;
    private float tempDuration;
    private float tempCountdown;

    protected override void SetUp()
    {
        base.SetUp();
        tempCountdown = countdown;
        tempDuration = duration;

        if (player.NeareastEnemy() != null )
        {
            Vector2 enemyPos = player.NeareastEnemy().transform.position;
            Vector2 spawnPos = new Vector2(enemyPos.x - 0.5f, enemyPos.y);
            GameObject skill = Instantiate(skillPrefab, spawnPos, Quaternion.identity);
            skill.GetComponent<Spell3SetUp>().Activate(duration);
        }
        else
        {
            canUseSkill = true;
           
            countdown = 0;
            duration = 0;
        }
    }
    protected override void ToExitCodition()
    {
        StartCoroutine(ExitCondition());
    }
    private IEnumerator ExitCondition()
    {
        yield return new WaitForSeconds(duration);
        base.ToExitCodition();
    }
    protected override void AfterExit()
    {
        base.AfterExit();
        countdown = tempCountdown;
        duration = tempDuration;
    }
}
