using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileObject : MonoBehaviour
{
    [SerializeField] private float time;
    private float timer;
    private bool isCollide;
    private Vector2 initPos;

    void Start()
    {
        timer = time;
        initPos = transform.position;
    }


    void Update()
    {
        if (isCollide)
        {
            StartCoroutine(ShakeRoutine());
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    IEnumerator ShakeRoutine()
    {
        while (true)
        {
            Vector3 temp = new Vector3 (Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f));
            transform.position += temp;
            yield return new WaitForSeconds(0.1f);
            transform.localPosition -= temp;
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
            isCollide = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            
            isCollide = false;
            timer = time;
            StopCoroutine(ShakeRoutine());
            transform.position = initPos;
        }
    }
  
}
