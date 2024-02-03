using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLight : MonoBehaviour
{
    private Light2D light2D;
    void Start()
    {
        light2D = GetComponent<Light2D>();
    }

    public void TurnOn(float speed)
    {
        if (light2D.intensity == 1)
            return;

        StopAllCoroutines();
        StartCoroutine(TurnOnRoutine(speed));
    }
    public void TurnOff(float speed)
    {
        if (light2D.intensity == 0)
            return;

        StopAllCoroutines();
        StartCoroutine(TurnOffRoutine(speed));
    }
    IEnumerator TurnOffRoutine(float speed)
    {
        while (light2D.intensity > 0.05)
        {
            light2D.intensity -= Time.deltaTime * speed;
            yield return null;
        }
        light2D.intensity = 0;
    }
    IEnumerator TurnOnRoutine(float speed)
    {
        while (light2D.intensity < 0.955)
        {
            light2D.intensity += Time.deltaTime * speed;
            yield return null;
        }
        light2D.intensity = 1;
    }

}

