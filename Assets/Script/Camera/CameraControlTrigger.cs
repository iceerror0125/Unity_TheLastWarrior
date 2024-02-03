using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

public class CameraControlTrigger : MonoBehaviour
{
    public CustomInspectorObjects custom;
    private Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            if (custom.panCameraOnContact)
            {
                CameraManager.instance.PanCameraOnContact(custom.panDistance, custom.panTime, custom.panDirection, false);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            Vector2 exitDirection = (collision.transform.position - coll.bounds.center).normalized;
            if (custom.swapCameras && custom.cameraOnLeft != null && custom.cameraOnRight != null)
            {
            
                CameraManager.instance.SwapCamera(custom.cameraOnLeft, custom.cameraOnRight, exitDirection);
            }
            if (custom.panCameraOnContact)
            {
                CameraManager.instance.PanCameraOnContact(custom.panDistance, custom.panTime, custom.panDirection, true);
            }
        }
    }
}

[System.Serializable]
public class CustomInspectorObjects
{
    public bool swapCameras = false;
    public bool panCameraOnContact = false;

    [HideInInspector] public CinemachineVirtualCamera cameraOnLeft;
    [HideInInspector] public CinemachineVirtualCamera cameraOnRight;

    [HideInInspector] public PanDirection panDirection;
    [HideInInspector] public float panDistance = 0.3f;
    [HideInInspector] public float panTime = 0.35f;
}

public enum PanDirection
{
    Up, Down, Left, Right
}

[CustomEditor(typeof(CameraControlTrigger))]
public class MyScriptEditor : Editor
{
    CameraControlTrigger cameraControlTrigger;

    private void OnEnable()
    {
        cameraControlTrigger = (CameraControlTrigger)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (cameraControlTrigger.custom.swapCameras)
        {
            cameraControlTrigger.custom.cameraOnLeft = EditorGUILayout.ObjectField("Camera On Left", cameraControlTrigger.custom.cameraOnLeft,
                typeof(CinemachineVirtualCamera), true) as CinemachineVirtualCamera;
            cameraControlTrigger.custom.cameraOnRight = EditorGUILayout.ObjectField("Camera On Right", cameraControlTrigger.custom.cameraOnRight,
              typeof(CinemachineVirtualCamera), true) as CinemachineVirtualCamera;
        }

        if (cameraControlTrigger.custom.panCameraOnContact)
        {
            cameraControlTrigger.custom.panDirection = (PanDirection)EditorGUILayout.EnumPopup("Camera Pan Direction",
                cameraControlTrigger.custom.panDirection);
            cameraControlTrigger.custom.panDistance = EditorGUILayout.FloatField("Pan Distance",
                cameraControlTrigger.custom.panDistance);
            cameraControlTrigger.custom.panTime = EditorGUILayout.FloatField("Pan Time",
                cameraControlTrigger.custom.panTime);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(cameraControlTrigger);
        }
    }
}