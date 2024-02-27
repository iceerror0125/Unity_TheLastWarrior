using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuOption : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image img;
    private AudioSource radio;
    public MainMenuController controller;
    public AudioClip sfxHover;
    public AudioClip sfxClick;
    public CheckpointData checkpoint;

    private void Start()
    {
        img = GetComponent<Image>();
        radio = GetComponent<AudioSource>();

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        radio.Stop();
        radio.clip = sfxHover;
        radio.Play();
        img.color = new Color(0.6f, 0.6f, 0.6f, 1);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        img.color = Color.white;
    }
    public void StartGame()
    {
        if (!controller.isClickable)
        {
            EnterGame();
            ResetData();
        }
    }

    private void ResetData()
    {
       /* // delete checkpoint
        if (checkpoint  != null)
        {
            checkpoint.key = "";
        }*/
        // playerPrefs
        PlayerPrefs.DeleteAll();
        // delete data file
        SaveManager.instance.DeleteFileSave();
        //GameManager.Instance.isRespawn = true;
        GameManager.Instance.isInMainMenu = true;

    }

    private void EnterGame()
    {
        radio.Stop();
        radio.clip = sfxClick;
        radio.Play();

        controller.isClickable = true;
        BlackScreen.instance.FadeIn();
        GameManager.Instance.isRespawn = true;

        InvokeRepeating("LoadScene", 1, 0.5f);
    }

    private void LoadScene()
    {
        if (BlackScreen.instance.IsFill())
        {
            //SceneManager.LoadScene("Scene_1");
            string scene = PlayerPrefs.GetString(checkpoint.key, "Scene_1");
            SceneManager.LoadScene(scene);
        }
    }
    public void Continue()
    {
        EnterGame();
    }
    public void ExitGame()
    {
        if (!controller.isClickable)
        {
            // save any game data here
#if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
            controller.isClickable = true;
        }

    }


}
