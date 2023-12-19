using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemData item;
    private SpriteRenderer sr;
    private CollectItemManager manager;
    private DialogManager dialogManager;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        manager = CollectItemManager.instance;
        dialogManager = DialogManager.instance;
        sr.sprite = item.Img;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckShowDialog();

        if (collision.GetComponent<Player>() != null)
        {
            Inventory.instance.AddItem(item);
            manager.CollectedItem(item.ItemName);
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
}
