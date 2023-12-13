using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimation : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float moveTimer;
    [SerializeField] private float timer;
    [SerializeField] private bool isUp;
    void Start()
    {
        speed = 0.005f;
        moveTimer = 0.5f;

        isUp = true;
        timer = moveTimer;

    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            if (isUp)
            {
                speed = Mathf.Abs(speed);
            }   
            else
            {
                speed = Mathf.Abs(speed) * -1;
            }
            timer = moveTimer;
            isUp = !isUp;
        }

        transform.position = new Vector2(transform.position.x, transform.position.y + speed);
    }
}
