using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    [SerializeField] private CinemachineVirtualCamera[] allVirtualCameras;
    [Header("Transposer")]
    [SerializeField] private float dampingAmount;
    [SerializeField] private float dampingTime;
    [SerializeField] private float yVDamping;
    [SerializeField] private float distanceFromGround;
    private float normDamping;

    public CinemachineVirtualCamera currentCamera;
    private CinemachineFramingTransposer transposer;

    private Coroutine panCameraCoroutine;

    private Vector2 startingTreckedObjectOffset;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance.gameObject);

        for (int i = 0; i < allVirtualCameras.Length; i++)
        {
            if (allVirtualCameras[i].enabled)
            {
                currentCamera = allVirtualCameras[i];
                transposer = currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            }
        }

        normDamping = transposer.m_YDamping;
        startingTreckedObjectOffset = transposer.m_TrackedObjectOffset;
    }
    public void InterpolateYAxis(bool isFalling)
    {
        StartCoroutine(InterpolateYAxisRoutine(isFalling));
    }
    private IEnumerator InterpolateYAxisRoutine(bool isFalling)
    {
        float start, end, elapsedTime = 0;
        start = normDamping;
        end = dampingAmount;
        if (!isFalling)
        {
            StopCoroutine(InterpolateYAxisRoutine(false));
            transposer.m_YDamping = 2;
        }
        else
        {

            while (elapsedTime < dampingTime)
            {
                elapsedTime += Time.deltaTime;
                float lerpedPanAmout = Mathf.Lerp(start, end, (elapsedTime / dampingTime));
                transposer.m_YDamping = lerpedPanAmout;
                yield return null;
            }
        }
    }
    public void PanCameraOnContact(float panDistance, float panTime, PanDirection panDirection, bool panToStartingPos)
    {
        panCameraCoroutine = StartCoroutine(PanCameraRoutine(panDistance, panTime, panDirection, panToStartingPos));
    }

    private IEnumerator PanCameraRoutine(float panDistance, float panTime, PanDirection panDirection, bool panToStartingPos)
    {
        Vector2 endPos = Vector2.zero;
        Vector2 startingPos = Vector2.zero;

        if (!panToStartingPos)
        {
            switch (panDirection)
            {
                case PanDirection.Up: endPos = Vector2.up; break;
                case PanDirection.Down: endPos = Vector2.down; break;
                case PanDirection.Left: endPos = Vector2.left; break;
                case PanDirection.Right: endPos = Vector2.right; break;
                default: break;
            }
            endPos *= panDistance;
            startingPos = startingTreckedObjectOffset;
            endPos += startingPos;
        }
        else
        {
            startingPos = transposer.m_TrackedObjectOffset;
            endPos = startingTreckedObjectOffset;
        }

        float elapsedTime = 0f;
        while (elapsedTime < panTime)
        {
            elapsedTime += Time.deltaTime;

            Vector3 panLerp = Vector3.Lerp(startingPos, endPos, (elapsedTime / panTime));
            transposer.m_TrackedObjectOffset = panLerp;
            yield return null;
        }
    }
    public void SwapCamera(CinemachineVirtualCamera cameraOut, CinemachineVirtualCamera cameraIn)
    {
       /* bool isRightDownOut = triggerExitDirection.x > 0f || triggerExitDirection.y < 0f;
        bool isLeftUpOut = triggerExitDirection.x < 0f || triggerExitDirection.y > 0f;*/
        if (currentCamera == cameraOut )
        {
            cameraIn.enabled = true;
            cameraOut.enabled = false;
            currentCamera = cameraIn;
            transposer = currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        }
       /* else if (currentCamera == cameraIn)
        {
            cameraOut.enabled = true;
            cameraIn.enabled = false;
            currentCamera = cameraOut;
            transposer = currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();

        }*/
    }

    private void OnShake(float duration, float strength)
    {
        currentCamera.transform.DOShakePosition(duration, strength);
        currentCamera.transform.DOShakeRotation(duration, strength);
    }
    public void ShakeCamera(float duration, float strength) => OnShake(duration, strength);
}
