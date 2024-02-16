using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraExpand : MonoBehaviour
{
    private CinemachineFramingTransposer transposer;
    private Vector3 originalTracked;
    private float timer = 1.5f;
    [Header("Config")]
    public float offset = 7f;
    public float speed = 1;
    void Start()
    {
        transposer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
        originalTracked = transposer.m_TrackedObjectOffset;
    }


    void Update()
    {
        ExpandCameraUpDown(KeyCode.UpArrow, true);
        ExpandCameraUpDown(KeyCode.DownArrow, false);

    }

    private void ExpandCameraUpDown(KeyCode key, bool isUp)
    {
        if (Input.GetKey(key))
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                /* transposer.m_TrackedObjectOffset = new Vector3(
                     transposer.m_TrackedObjectOffset.x,
                     isUp ? transposer.m_TrackedObjectOffset.y + offset : transposer.m_TrackedObjectOffset.y - offset,
                     transposer.m_TrackedObjectOffset.z);*/
                if (isUp)
                {
                    StartCoroutine(ExpandCameraRoutine(transposer.m_TrackedObjectOffset.y + offset));
                }
                else
                {
                    speed *= -1;
                    StartCoroutine(ExpandCameraRoutine(transposer.m_TrackedObjectOffset.y - offset));

                }
                timer = float.MaxValue;
            }
        }
        if (Input.GetKeyUp(key))
        {
            timer = 1.5f;
            speed = Mathf.Abs(speed);
            transposer.m_TrackedObjectOffset = originalTracked;
        }
    }

    private IEnumerator ExpandCameraRoutine(float target)
    {
        float temp = target;
        while (temp > 0.3f)
        {
            transposer.m_TrackedObjectOffset.y += speed;
            temp -= Mathf.Abs(speed);
            yield return null;
        }
        transposer.m_TrackedObjectOffset.y = target;
    }
}
