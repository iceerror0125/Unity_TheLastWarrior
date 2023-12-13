using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HPBar : MonoBehaviour
{
    [SerializeField] private EntityStat stat;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        stat.onChangeHP += UpdateHPBar;
        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        Debug.Log(stat);
        slider.maxValue = stat.MaxHp;
        slider.value = stat.Hp;
    }
}
