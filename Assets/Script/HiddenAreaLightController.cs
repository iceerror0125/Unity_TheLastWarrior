using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HiddenAreaLightController : MonoBehaviour
{
    private Light2D global;
    [SerializeField] private GameObject hiddenLight;
    [SerializeField] private float speed;
    private bool isStaying;
    void Start()
    {
        global = GameObject.Find("Global Light").GetComponent<Light2D>();
    }


    private void TurnOnLight()
    {
        StartCoroutine(TurnOnRoutine());
        hiddenLight.SetActive(false);

    }

    private void TurnOffLight()
    {
        StartCoroutine(TurnOffRoutine());
        hiddenLight.SetActive(true);

    }
    IEnumerator TurnOnRoutine()
    {
        while (global.intensity < 0.955)
        {
            global.intensity += Time.deltaTime * speed;
            yield return null;
        }
        global.intensity = 1;
    }

    IEnumerator TurnOffRoutine()
    {
        isStaying = true;
        while (global.intensity > 0.05)
        {
            global.intensity -= Time.deltaTime * speed;
            yield return null;
        }
        global.intensity = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            if (!isStaying)
            {
                TurnOffLight();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            isStaying = false;
            TurnOnLight();
        }
    }
}
