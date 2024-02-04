using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource sfx;
    [SerializeField] private AudioClip footStep;
    [SerializeField] private AudioClip dead;
    [SerializeField] private AudioClip scroll;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip healSpell;
    [SerializeField] private AudioClip attack;
    [SerializeField] private AudioClip hit;

    private void Start()
    {
        sfx = GetComponent<AudioSource>();
    }
    public void Init()
    {
        Start();
    }
    public void FootStep()
    {
        PlaySFX(footStep);
    }
    public void Dead()
    {
        PlaySFX(dead);
    }
    public void Scroll()
    {
        PlaySFX(scroll);
    }
    public void Jump()
    {
        PlaySFX(jump);
    }
   
    public void HealSpell()
    {
        PlaySFX(healSpell);
    }
    public void Attack()
    {
        PlaySFX(attack);
    }
    public void Hit()
    {
        PlaySFX(hit);
    }
    private void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfx.Stop();
            sfx.clip = clip;
            sfx.Play();
        }
    }

}
