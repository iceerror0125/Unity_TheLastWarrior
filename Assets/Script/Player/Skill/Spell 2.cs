using System.Collections;
using UnityEngine;

public class Spell2 : PlayerSkill
{
    [SerializeField] private GameObject skillPrefab;
    private int counter;
    protected override void SetUp()
    {
        base.SetUp();
        if (player == null)
            return;

        if (player.NeareastEnemy() == null)
        {
            counter = 0;
            return;
        }

        counter = 3;
        StartCoroutine(SpawnBullet());
    }
    private IEnumerator SpawnBullet()
    {
        while (counter > 0)
        {
            Vector2 spawnPos = new Vector2(player.transform.position.x, player.transform.position.y + 10);
            GameObject skill = Instantiate(skillPrefab, spawnPos, Quaternion.identity);
            skill.GetComponent<Spell2SetUp>().Activate();

            counter--;
            yield return new WaitForSeconds(1);
        }
    }
    protected override void ToExitCodition()
    {
        StartCoroutine(WaitingCounter());
    }
    private IEnumerator WaitingCounter()
    {
        while (counter > 0)
        {
            yield return null;
        }
        base.ToExitCodition();
    }
}
