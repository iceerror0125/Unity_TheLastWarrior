using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;

    private Vector2 offset;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    public void Activate()
    {
        CloseGate();
    }
    public void Deactivate()
    {
        OpenGate();
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
        AudioManager.instance.environment.OpenGate();
        if (this != null)
        {
            StartCoroutine(MoveGateRoutine());

        }
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
        AudioManager.instance.environment.SlamGate();

        StartCoroutine(MoveGateRoutine());
    }

    private IEnumerator MoveGateRoutine()
    {
        transform.position += (Vector3)offset * 0.5f; // plus little range to negate collision Enter
        offset *= speed;
        rb.bodyType = RigidbodyType2D.Dynamic;

        while (true)
        {
            rb.AddForce(offset);
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        offset = Vector2.zero;
        StopAllCoroutines();
        rb.bodyType = RigidbodyType2D.Static;
        GameManager.Instance.isCutScene = false;
    }
}
