using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateWall : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CloseGate();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            OpenGate();
        }
    }

    public void CloseGate()
    {
        rb.gravityScale = 10;
    }
    public void OpenGate()
    {
        rb.gravityScale = 0;
        StartCoroutine(OpenGateCoroutine());
    }
    private IEnumerator OpenGateCoroutine()
    {
        Vector2 target = transform.parent.transform.position;
        while (transform.position.y != target.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 10 * Time.deltaTime);
            yield return null;
        }
    }
}
