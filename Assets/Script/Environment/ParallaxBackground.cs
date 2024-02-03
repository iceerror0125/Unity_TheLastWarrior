using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float speed;
    private float xPos;
    private float xCamPos;
    void Start()
    {
       
        xPos = transform.position.x;
    }

    void Update()
    {
        xCamPos = GameObject.Find("Player").transform.position.x;
        float dir = xCamPos * speed;
        transform.position = new Vector2(xPos + dir , transform.position.y);
    }
}
