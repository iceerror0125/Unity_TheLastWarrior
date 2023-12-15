using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [Header("Basic Attributes")]
    [SerializeField] protected bool isUnlock = false;
    [SerializeField] protected bool isActiveSkill;
    [SerializeField] protected float countdown;
    [SerializeField] protected float duration;
    [SerializeField] protected Sprite img;
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
        ToExitCodition();
    }
    protected virtual void SetUp() { }
    protected virtual void ToExitCodition() => Exit();
    protected virtual void Exit()
    {
        isExitCalled = true;
        StartCoroutine(EnableCanUseSkill());
    }
    private IEnumerator EnableCanUseSkill()
    {
        yield return new WaitForSeconds(countdown);
        canUseSkill = true;
        isExitCalled = false;
    }



}
