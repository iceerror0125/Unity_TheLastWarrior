using System.Collections.Generic;
using UnityEngine;


public class CollectItemManager : MonoBehaviour
{
    public static CollectItemManager instance;
    private Dictionary<string, bool> dic;
    [SerializeField] private List<ItemData> items;

    private void Awake()
    {

        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        dic = new Dictionary<string, bool>();
        // convert list to dictinary (add item to dictionary)
        foreach (ItemData item in items)
        {
            dic.Add(item.id, false);
        }
    }

    public bool IsCollectNewItem(string _itemId)
    {
        foreach (var pair in dic)
        {
            /* Debug.Log(pair.Key + " - " + pair.Value);
             Debug.Log("New: " + _itemId);
             Debug.Log("Compare: " + (pair.Key.Equals(_itemId)));*/
            if (pair.Key.Equals(_itemId) && pair.Value)
            {
                return false;
            }
        }
        return true;
        /* if (dic.TryGetValue(_itemName, out bool result))
         {
             if (result == false)
                 return true;
         }
         return false;*/
    }
    public void CollectedItem(string _itemId)
    {
        //Debug.Log("New: " + _itemId);
        //Debug.Log(dic.ContainsKey(_itemId));
        if (dic.ContainsKey(_itemId))
        {
            dic[_itemId] = true;
        }
    }
}
