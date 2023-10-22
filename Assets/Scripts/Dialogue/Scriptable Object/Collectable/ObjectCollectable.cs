using UnityEngine;
using System;

public class ObjectCollectable : MonoBehaviour, ICollectable
{   
    [SerializeField] ItemData itemData;
    [SerializeField] InventorySystem inventorySystem;

    public void AddObject()
    {
        inventorySystem.AddToInventory(itemData);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
