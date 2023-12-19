using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HPBar : MonoBehaviour
{
    [SerializeField] private EntityStat stat;
    [SerializeField] private Slider hpLostSlider;
    [SerializeField] private float speed;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        stat.onChangeHP += UpdateHPBar;


        slider.maxValue = stat.MaxHp;
        hpLostSlider.maxValue = stat.MaxHp;
        UpdateHPBar(0);
    }

    private void UpdateHPBar(float damage)
    {
        slider.value = stat.Hp;
        //Invoke("UpdateHPLostSlider", 0.5f);
        StartCoroutine(GraduallyDecreaseHP(damage));
    }

    private IEnumerator GraduallyDecreaseHP(float damage)
    {
        float targetValue = slider.value;
        while (hpLostSlider.value > targetValue)
        {
            hpLostSlider.value -= Time.deltaTime * speed * (damage / 2);
            yield return null;
        }
        hpLostSlider.value = slider.value-1;
    }
}
