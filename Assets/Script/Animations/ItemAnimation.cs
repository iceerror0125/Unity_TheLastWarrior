using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimation : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] float height = 0.02f;

    void Update()
    {
        if (GameManager.Instance.isGamePaused) return;
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed);
        //set the object's Y to the new calculated Y
    
       transform.position = new Vector2(transform.position.x, transform.position.y + newY * height);
    }
}
