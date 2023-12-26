using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : PlayerSkill
{
    // Player's velocity is zero while activating skill.
    // Skill will be in front of player (left and right)
    [SerializeField] private GameObject skillPrefab;
    [SerializeField] private float x;

    private UltimateSetUp script;

    protected override void SetUp()
    {
        base.SetUp();

        Vector2 spawnPos = new Vector2 (player.transform.position.x + player.EntityDir() * x, player.transform.position.y);
        GameObject skill = Instantiate(skillPrefab, spawnPos, Quaternion.identity); 
        script = skill.GetComponent<UltimateSetUp>();
        if (player.EntityDir() < 0 )
        {
            script.ReverseRotation();
        }
        script.Activate();
    }
    protected override void ToExitCodition()
    {
        StartCoroutine(ToExit());
    }
    private IEnumerator ToExit()
    {
        yield return new WaitForSeconds(duration);
        script.DestroySkill();
        base.ToExitCodition();
    }
}
