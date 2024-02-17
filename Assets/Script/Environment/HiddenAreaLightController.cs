using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HiddenAreaLightController : MonoBehaviour
{
    private GlobalLight global;
    [SerializeField] private GameObject hiddenLight;
    [SerializeField] private float speed;
    void Start()
    {
        global = GameObject.Find("Global Light").GetComponent<GlobalLight>();
    }


    private void TurnOnLight()
    {
        if (global != null)
        {
            global.TurnOn(speed);
            hiddenLight.SetActive(false);
        }
    }

    private void TurnOffLight()
    {
        if (global != null)
        {
            global.TurnOff(speed);
            hiddenLight.SetActive(true);
        }
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            TurnOffLight();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            TurnOnLight();
        }
    }
}
