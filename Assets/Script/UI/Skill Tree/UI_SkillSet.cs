using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SkillSet : MonoBehaviour
{
    [SerializeField] private Image a;
    [SerializeField] private Image s;
    [SerializeField] private Image d;

    private void Start()
    {
        a.sprite = null;
        s.sprite = null;
        d.sprite = null;    
    }

    public void SetA(Sprite _img)
    {
        a.sprite = _img;
    }
    public void SetS(Sprite _img)
    {
        s.sprite = _img;
    }
    public void SetD(Sprite _img)
    {
        d.sprite = _img;
    }

}
