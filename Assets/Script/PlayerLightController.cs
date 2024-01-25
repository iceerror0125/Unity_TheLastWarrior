using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLightController : MonoBehaviour
{
    private GameObject player;
    private Light2D light2D;
    [SerializeField] private float maxIntensity = 1;
    void Start()
    {
        player = GameObject.Find("Player");
        light2D = player.GetComponentInChildren<Light2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            if (light2D.intensity == 0)
                light2D.intensity = maxIntensity;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            if (light2D.intensity == maxIntensity)
                light2D.intensity = 0;
        }

    }
}
