using System;
[Serializable]
public class InventoryItem
{
    private ItemData item;
    private int amount;

    public InventoryItem(ItemData item)
    {
        this.item = item;
        this.amount = 1;
    }

    public ItemData Item => item;
    public int Amount => amount;
    public void Plus()
    {
        amount++;
    }
    public void Decrease()
    {
        if (amount > 0)
        {
            amount--;
        }
    }
}
