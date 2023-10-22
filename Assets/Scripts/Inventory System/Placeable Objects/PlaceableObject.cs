using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : MonoBehaviour, IPlaceable
{
    [SerializeField] private GameObject objectToPlace;
    [SerializeField] private ItemData itemData;
    [SerializeField] InventorySystem inventorySystem;

    public void PlaceObject(ItemData data)
    {
        if(data == itemData)
        {
            inventorySystem.RemoveFromInventory(itemData);
            gameObject.SetActive(false);
            if(objectToPlace != null) objectToPlace.SetActive(true);
        }    
    }
}
