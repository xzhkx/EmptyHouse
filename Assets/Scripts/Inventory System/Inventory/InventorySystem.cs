using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[SerializeField]
public class InventorySystem : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();
    [SerializeField] private List<GameObject> inventorySlots = new List<GameObject>();
    private Dictionary<ItemData, InventoryItem> inventoryDictionary = new Dictionary<ItemData, InventoryItem>();

    private int currentSlot;

    private void Awake()
    {
        currentSlot = 0;
    }

    public void AddToInventory(ItemData itemData)
    {
        InventoryItem newItem = new InventoryItem(itemData);
        inventory.Add(newItem);
        inventoryDictionary.Add(itemData, newItem);

        UpdateInventory();
        inventorySlots[0].transform.GetChild(1).gameObject.SetActive(true);
    }

    public void RemoveFromInventory(ItemData itemData)
    {
        if(inventoryDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            inventoryDictionary.Remove(itemData);
            inventory.Remove(item);
            item.RemoveItem();
            currentSlot--;
            UpdateInventory();
            Debug.Log(inventory.Count);
        }
    }   

    private void UpdateInventory()
    {
        foreach(GameObject itemUI in inventorySlots)
        {
            itemUI.SetActive(false);
            if(inventory.Count > 0)
            {
                for (int k = 0; k < inventory.Count; k++)
                {
                    inventorySlots[k].transform.GetChild(1).gameObject.SetActive(false);
                    inventorySlots[k].GetComponentInChildren<TextMeshProUGUI>().text = inventory[k].itemData.displayName;
                    inventorySlots[k].SetActive(true);
                }

            }      
        }
    }
}
