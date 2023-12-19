using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SetSkillDialog : MonoBehaviour
{
    private Image a;
    private Image s;
    private Image d;
    private SkillManager manager;
    private PlayerSkill skill;

    void Start()
    {
        a = GetComponentsInChildren<Image>()[1];
        s = GetComponentsInChildren<Image>()[2];
        d = GetComponentsInChildren<Image>()[3];

        manager = SkillManager.instance;
    }

    public void ShowDialog(PlayerSkill _skill)
    {
        skill = _skill;
        gameObject.SetActive(true);
        Start();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            manager.SetA(skill);
            gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            manager.SetS(skill);
            gameObject.SetActive(false);
        }
        if (Input.GetKeyDown (KeyCode.D))
        {
            manager.SetD(skill);
            gameObject.SetActive(false);
        }
    }
}
