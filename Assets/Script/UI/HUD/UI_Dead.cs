using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Dead : MonoBehaviour
{
    private TextMeshProUGUI text1;
    private TextMeshProUGUI text2;

    void Start()
    {
        text1 = GetComponentsInChildren<TextMeshProUGUI>()[0];
        text2 = GetComponentsInChildren<TextMeshProUGUI>()[1];
        BlackScreen.instance.FadeIn();
        Invoke("FadeIn", 1);
    }

   
    void Update()
    {
        if (text2.color.a > 0.8f)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Respawn();
            }
        }
        
    }

    private void Respawn()
    {
        var manager = CheckpointManager.instance;
        if (manager.data.scene.Contains("Scene"))
        {
            string name = manager.data.scene;
            GameManager.Instance.isRespawn = true;
            SceneManager.LoadScene(name);
        }
        else
        {
            SceneManager.LoadScene("Scene_1");
        }
    }

    private void FadeIn()
    {
        text1.color = new Color(1, 0, 0, 0);
        text2.color = new Color(1, 1, 1, 0);
        StartCoroutine(FadeOutRoutine());
    }
    private IEnumerator FadeOutRoutine()
    {
        float speed = 0.5f;
        while (text1.color.a < 0.9)
        {
            text1.color = new Color(1, 0, 0, text1.color.a + Time.deltaTime * speed);
            text2.color = new Color(1, 1, 1, text2.color.a + Time.deltaTime * speed);
            yield return null;
        }
        text1.color = Color.red;
        text2.color = Color.white;
    }
}
