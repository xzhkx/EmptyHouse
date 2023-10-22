using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnseeItemCollectable : MonoBehaviour, ICollectable
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private InventorySystem inventorySystem;

    public void AddObject()
    {
        inventorySystem.AddToInventory(itemData);
        gameObject.SetActive(false);
    }
}
