using UnityEngine;

public class Spell1 : PlayerSkill
{
    [SerializeField] private GameObject skillPrefab;

    protected override void SetUp()
    {
        base.SetUp();
        Player player = PlayerManager.instance.player;
        GameObject skill = Instantiate(skillPrefab, player.transform.position, Quaternion.identity);
        skill.GetComponent<Spell1Animation>().Activate();
    }
}
