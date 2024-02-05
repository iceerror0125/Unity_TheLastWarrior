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
        stat.onChangeHP += DecreaseHPEffect;


        slider.maxValue = stat.MaxHp;
        hpLostSlider.maxValue = stat.MaxHp;
        DecreaseHPEffect(0);
    }

    public void DecreaseHPEffect(float damage)
    {
        slider.value = stat.Hp;
        //Invoke("UpdateHPLostSlider", 0.5f);
        StartCoroutine(GraduallyDecreaseHP(damage));
    }
    public void UpdateHP()
    {
        slider.maxValue = stat.MaxHp;
        hpLostSlider.maxValue = stat.MaxHp;
        slider.value = stat.Hp;
        hpLostSlider.value = stat.Hp;
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
