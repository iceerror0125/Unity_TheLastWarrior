using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private bool isBattle;

    private Vector2 offset;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

    }

    void Update()
    {
        rb.AddForce(offset);

        if (isBattle)
        {
            CloseGate();
        }
        else
        {
            OpenGate();
        }
    }

    public void Activate()
    {
        isBattle = true;
    }
    public void Deactivate()
    {
        isBattle = false;
    }

    private void OpenGate()
    {
        
        if (transform.parent.eulerAngles.z == 90)
        {
            offset = Vector2.right;
        }
        else
        {
            offset = Vector2.up;
        }
        offset *= speed;
    }
    private void CloseGate()
    {
        if (transform.parent.eulerAngles.z == 90)
        {
            offset = Vector2.left;
        }
        else
        {
            offset = Vector2.down;
        }
        offset *= speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        offset = Vector2.zero;
    }
}
