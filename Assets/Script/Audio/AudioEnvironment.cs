using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEnvironment : MonoBehaviour
{
    private AudioSource bg;
    private AudioSource sfx;
    private AudioSource backupSfx;

    [SerializeField] AudioClip bgTheme;
    [SerializeField] AudioClip bossTheme;
    [SerializeField] AudioClip breakWall;
    [SerializeField] AudioClip hitBreakWall;
    [SerializeField] AudioClip gateOpen;
    [SerializeField] AudioClip gateSlam;
    [SerializeField] AudioClip inventoryOpen;
    [SerializeField] AudioClip gameOver;
    [SerializeField] AudioClip menuSelect;
    [SerializeField] AudioClip pickUp;
    [SerializeField] AudioClip secretPlaceDiscovered;
    [SerializeField] AudioClip shakingGround;
    [SerializeField] AudioClip hitBySpike;
    [SerializeField] AudioClip enemyHurt;

    void Start()
    {
        bg = GetComponentsInChildren<AudioSource>()[0];
        sfx = GetComponentsInChildren<AudioSource>()[1];
        backupSfx = GetComponentsInChildren<AudioSource>()[2];
        PlayBGTheme();
    }
    public void Init()
    {
        Start();
    }
    public void PlayBGTheme()
    {
        PlayBG(bgTheme);
    }
    public void PlayBossTheme()
    {
        PlayBG(bossTheme);
    }
    public void BreakWall()
    {
        PlaySFX(breakWall);
    }
    public void HitBreakWall()
    {
        PlaySFX(hitBreakWall);
    }
    public void OpenGate()
    {
        PlaySFX(gateOpen);
    }
    public void SlamGate()
    {
        PlaySFX(gateSlam);
    }
    public void InventoryOpen()
    {
        PlaySFX(inventoryOpen);
    }
    public void GameOver()
    {
        PlaySFX(gameOver);
    }
    public void MenuSelect()
    {
        PlaySFX(menuSelect);
    }
    public void PickUpItem()
    {
        PlaySFX(pickUp);
    }
    public void DiscoverSecretPlace()
    {
        PlaySFX(secretPlaceDiscovered);
    }
    public void ShakeGround()
    {
        PlaySFX(shakingGround);
    }
    public void HitBySpike()
    {
        PlaySFX(hitBySpike);
    }
    public void EnemyHurt()
    {
        PlaySFX(enemyHurt);
    }

    private void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            if (sfx.isPlaying)
            {
                backupSfx.clip = clip;
                backupSfx.Play();
            }
            else
            {
                sfx.clip = clip;
                sfx.Play();
            }
        }

    }
    private void PlayBG(AudioClip clip)
    {
        if (clip != null)
        {
            /*bg.Stop();
            bg.clip = clip;
            bg.Play();*/
            StartCoroutine(ChangeClipRoutine(bg, clip));
        }
        else
        {
            bg.Stop();
        }
    }
    private IEnumerator ChangeClipRoutine(AudioSource audio, AudioClip clip)
    {
        float speed = 0.02f;
        // decrease volume
        while (audio.volume > 0.1)
        {
            audio.volume -= speed;
            yield return null;
        }
        audio.volume = 0;

        audio.Stop();
        audio.clip = clip;
        audio.Play();

        // increase volume
        while (audio.volume < 0.9)
        {
            audio.volume += speed;
            yield return null;
        }
        audio.volume = 1;
    }
}
