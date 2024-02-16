using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string transitionFromScene;
    public bool isCutScene;
    public bool isRespawn;
    public bool isGamePaused { get; private set; }
    public bool isUITurnedOn { get; private set; }
    public SaveManager saveManager { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        saveManager = SaveManager.instance;
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene("Scene_1");
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    public void TurnOnUI()
    {
        isUITurnedOn = true;
    }
    public void TurnOffUI()
    {
        isUITurnedOn = false;
    }

    private void OnSceneUnloaded(Scene current)
    {
        saveManager.SaveData();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!string.Equals(scene.path, SceneManager.GetActiveScene().path)) return;

        LoadSaveData();
    }
    private void LoadSaveData()
    {
        if (saveManager.ExistsFileSave())
        {
            saveManager.LoadData();
        }
    }
}
