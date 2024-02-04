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
            AudioManager.instance.environment.ShakeGround();

            StartCoroutine(ShakeRoutine());
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                AudioManager.instance.environment.BreakWall();

                Destroy(gameObject);
            }
        }
    }
    IEnumerator ShakeRoutine()
    {
        float range = 0.03f;
        while (true)
        {
            Vector3 temp = new Vector3(Random.Range(-range, range), Random.Range(-range, range));
            transform.position += temp;
            yield return new WaitForSeconds(0.1f);
            transform.localPosition -= temp;
            yield return new WaitForSeconds(0.1f);
        }
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            isCollide = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            isCollide = false;
            transform.position = initPos;
            StopAllCoroutines();
            timer = time;
        }
    }
}
