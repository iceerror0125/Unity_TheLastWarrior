using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UI_VolumeSetting : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string mixerName;
    [SerializeField] private float multiplier;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1;
    }

    public void ChangeVolume(float value)
    {
        mixer.SetFloat(mixerName, Mathf.Log10(value) * multiplier);
    }
}
