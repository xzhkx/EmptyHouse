using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingItemHandler : MonoBehaviour
{
    [SerializeField] private float amountToHeal;
    [SerializeField] private HealthBarController healthBarController;
    [SerializeField] private InventorySystem inventorySystem;

    public void AlmondWaterUseItem(ItemData data)
    {
        inventorySystem.RemoveFromInventory(data);
        healthBarController.TakeHealingAmount(amountToHeal);
    }
}
