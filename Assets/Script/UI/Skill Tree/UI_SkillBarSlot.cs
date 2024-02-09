using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SkillBarSlot : MonoBehaviour
{
    private Image skillImage;
    private Image countdownImage;
    private PlayerSkill skill;
    private float timer;

    public PlayerSkill Skill => skill;

    private void Start()
    {
        skillImage = GetComponentsInChildren<Image>()[0];
        countdownImage = GetComponentsInChildren<Image>()[1];
    }
    private void Update()
    {
        if (skill != null)
        {
            if (skill.CanUseSkill)
            {
                timer = skill.Countdown;
            }
            else
            {
                UnenabledImage();
                CountDown();
            }
        }
    }
    public void SetUpSlot(PlayerSkill _skill)
    {
        if (_skill == null)
        {
            TransparentImage();
        }
        else
        {
            skillImage.sprite = _skill.Img;
            countdownImage.sprite = _skill.Img;
            skill = _skill;
            EnabledImage();
        }

    }
    private void CountDown()
    {
        countdownImage.fillAmount = 1;

        if (skill.IsExitCalled)
        {
            timer -= Time.deltaTime;
            countdownImage.fillAmount = timer / skill.Countdown;
        }
    }
    private void EnabledImage()
    {
        skillImage.color = EnabledColor;
        //countdownImage.color = EnabledColor;
    }
    private void UnenabledImage()
    {
        countdownImage.color = UnenabledColor;
    }
    private void TransparentImage()
    {
        skillImage.color = TransparentColor;
        countdownImage.color = TransparentColor;
    }
    private Color TransparentColor => new Color32(0, 0, 0, 0);
    private Color EnabledColor => Color.white;
    private Color UnenabledColor => new Color32(113, 113, 113, 255);

}
