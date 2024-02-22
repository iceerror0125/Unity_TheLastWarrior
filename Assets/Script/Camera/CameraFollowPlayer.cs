using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    private Player player;
    private void Start()
    {
        player = PlayerManager.instance.player;
    }
    private void Update()
    {
        transform.position = player.transform.position;
    }
    public void RotateCamera()
    {
        if (this != null)
        {
            LeanTween.rotateY(gameObject, CameraRotation(), speed).setEaseInOutSine();
        }
    }
    private float CameraRotation()
    {
        bool isFaceRight = player.IsFacingRight;
        if (isFaceRight)
        {
            return 0;
        }
        return 180;
    }
}
