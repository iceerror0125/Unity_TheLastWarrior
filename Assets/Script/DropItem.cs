using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private List<GameObject> items;

    public void OnDropItem()
    {
        for (int i = 0; i < items.Count; i++)
        {
            GameObject go = Instantiate(items[i], new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
            Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
            Destroy(go.GetComponent<OneTimeAppear>());
            rb.gravityScale = 1;
            rb.AddForce(RandomSpawn(), ForceMode2D.Impulse);
        }
    }
    private Vector2 RandomSpawn()
    {
        int x = Random.Range(-5, 5);
        int y = Random.Range(1, 5);
        return new Vector2(x, y);
    }
}
