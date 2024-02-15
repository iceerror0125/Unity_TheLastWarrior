using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SkillSet : MonoBehaviour
{
    [SerializeField] private Image a;
    [SerializeField] private Image s;
    [SerializeField] private Image d;
    public PlayerSkill skillA { get; private set; }
    public PlayerSkill skillS { get; private set; }
    public PlayerSkill skillD { get; private set; }


  /*  private void Start()
    {
        a.sprite = null;
        s.sprite = null;
        d.sprite = null;
    }
*/
    public void SetA(PlayerSkill skill)
    {
        skillA = skill;
        a.sprite = skill?.Img;
    }
    public void SetS(PlayerSkill skill)
    {
        skillS = skill;
        s.sprite = skill?.Img;
    }
    public void SetD(PlayerSkill skill)
    {
        skillD = skill;
        d.sprite = skill?.Img;
    }

}
