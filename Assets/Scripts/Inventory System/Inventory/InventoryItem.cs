using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public ItemData itemData;
    public int stackSize;

    public InventoryItem(ItemData item)
    {
        itemData = item;
        AddItem();
    }
    
    public void AddItem()
    {
        stackSize++;
    }    

    public void RemoveItem()
    {
        if (stackSize > 0) stackSize--;
    }    
}
