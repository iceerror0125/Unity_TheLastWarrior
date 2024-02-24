using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemData item;
    private SpriteRenderer sr;
    private CollectItemManager manager;
    private DialogManager dialogManager;
    private float distance = 1f;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        manager = CollectItemManager.instance;
        dialogManager = DialogManager.instance;
        sr.sprite = item.Img;
    }

    private void Update()
    {
        if (CheckGround())
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.GetComponent<Player>() != null)
        {
            CheckShowDialog();
            Inventory.instance.AddItem(item);
            manager.CollectedItem(item.ItemName);
            AudioManager.instance.environment.PickUpItem();

            OneTimeAppear ota = GetComponent<OneTimeAppear>();
            if (ota != null)
            {
                ota.DestroyOTA();
            }

            Destroy(gameObject);
        }
    }

    private void CheckShowDialog()
    {
        if (manager.IsCollectNewItem(item.ItemName))
        {
            dialogManager.ShowInfoDialog(item);
        }
    }

    private bool CheckGround()
    {
        var x = Physics2D.Raycast(transform.position, Vector2.down, distance, 1 << 3);
        if (x)
        {
            return true;
        }
        return false;
    }

   /* private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - distance));
    }*/
}
