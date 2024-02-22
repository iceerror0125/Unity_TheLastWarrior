using Cinemachine;
#if UNITY_EDITOR
using UnityEditor;
#endif
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            
            if (custom.swapCameras && custom.cameraOut != null && custom.cameraIn != null)
            {

                CameraManager.instance.SwapCamera(custom.cameraOut, custom.cameraIn);
            }
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

            if (custom.swapCameras && custom.cameraOut != null && custom.cameraIn != null)
            {

                CameraManager.instance.SwapCamera(custom.cameraIn, custom.cameraOut);
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

    /*  [HideInInspector] public CinemachineVirtualCamera cameraOnLeft; 
      [HideInInspector] public CinemachineVirtualCamera cameraOnRight; */

    [HideInInspector] public CinemachineVirtualCamera cameraOut;
    [HideInInspector] public CinemachineVirtualCamera cameraIn;

    [HideInInspector] public PanDirection panDirection;
    [HideInInspector] public float panDistance = 0.3f;
    [HideInInspector] public float panTime = 0.35f;
}

public enum PanDirection
{
    Up, Down, Left, Right
}

#if UNITY_EDITOR
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
            cameraControlTrigger.custom.cameraOut = EditorGUILayout.ObjectField("Camera On Left", cameraControlTrigger.custom.cameraOut,
                typeof(CinemachineVirtualCamera), true) as CinemachineVirtualCamera;
            cameraControlTrigger.custom.cameraIn = EditorGUILayout.ObjectField("Camera On Right", cameraControlTrigger.custom.cameraIn,
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
#endif