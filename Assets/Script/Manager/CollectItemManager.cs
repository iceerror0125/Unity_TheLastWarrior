using System.Collections.Generic;
using UnityEngine;


public class CollectItemManager : MonoBehaviour
{
    public static CollectItemManager instance;
    [SerializeField] private Dictionary<string, bool> dic;
    [SerializeField] private List<ItemData> items;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
    }
    void Start()
    {
        dic = new Dictionary<string, bool>();
        // convert list to dictinary (add item to dictionary)
        foreach (ItemData item in items)
        {
            dic.Add(item.ItemName, false);
        }
    }

    public bool IsCollectNewItem(string _itemName)
    {
        if (dic.TryGetValue(_itemName, out bool result))
        {
            if (result == false)
                return true;
        }
        return false;
    }
    public void CollectedItem(string _itemName)
    {
        if (dic.ContainsKey(_itemName))
        {
            dic[_itemName] = true;
        }
    }
}
