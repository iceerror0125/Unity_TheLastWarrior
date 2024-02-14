using System.Collections;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [Header("Basic Attributes")]
    [SerializeField] protected bool isUnlock = false;
    [SerializeField] protected bool isActiveSkill;
    [SerializeField] protected float countdown;
    [SerializeField] protected float duration;
    [SerializeField] protected Sprite img;
    public float counteddownTime;

    [Space]
    [SerializeField] protected string skillName;
    [TextArea]
    [SerializeField] protected string description;

    protected Player player;

    protected bool canUseSkill = true;
    private bool isExitCalled;

    #region Get Set
    public bool IsUnlock => isUnlock;
    public void Unlock(bool _value) => isUnlock = _value;
    public bool IsActiveSkill => isActiveSkill;
    public float Countdown => countdown;
    public float Duration => duration;
    public Sprite Img => img;
    public bool CanUseSkill => canUseSkill;
    public bool IsExitCalled => isExitCalled;
    public string SkillName => skillName;
    public string Description => description;
    #endregion

    private void Start()
    {
        player = PlayerManager.instance.player;
    }
    public void Activate()
    {
        if (canUseSkill == false)
            return;

        canUseSkill = false;
        SetUp();
        UI_PlayerStat.instance.UpdateStat();

        ToExitCodition();
    }
    protected virtual void SetUp() { }
    protected virtual void ToExitCodition() => Exit();
    protected virtual void Exit()
    {
        UI_PlayerStat.instance.UpdateStat();
        isExitCalled = true;
        StartCoroutine(EnableCanUseSkill());
    }
    private IEnumerator EnableCanUseSkill()
    {
        yield return new WaitForSeconds(countdown);
        canUseSkill = true;
        isExitCalled = false;

        AfterExit();
        // Debug.Log(countdown + " - " + duration);
        // auto activate for passive skill
        if (!isActiveSkill)
        {
            Activate();
        }
    }
    protected virtual void AfterExit() { }

    public override string ToString()
    {
        return base.ToString();
    }
}
