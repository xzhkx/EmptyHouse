using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItemHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> selectIcon;
    [SerializeField] private GameObject inventorypanel;
    private InventorySystem inventorySystem;

    private int currentChoice;
    private int maxChoice;

    private void Awake()
    {
        inventorySystem = GetComponent<InventorySystem>();                
    }

    private void Update()
    {
        if (!inventorypanel.activeInHierarchy) return;

        maxChoice = inventorySystem.inventory.Count;
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            IconDownArrrow();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            IconUpArrow();
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            ItemData data = inventorySystem.inventory[currentChoice].itemData;
            OnPlaceObjectEvent.PlaceObjectEventHandler?.Invoke(data);
            inventorypanel.SetActive(false);
        }
    }

    public void ResetInventoryPanel()
    {
        currentChoice = 0;
        foreach(GameObject icon in selectIcon)
        {
            icon.SetActive(false);
        }
        selectIcon[0].SetActive(true);
    }

    private void IconDownArrrow()
    {
        if (currentChoice < maxChoice - 1)
        {
            selectIcon[currentChoice].SetActive(false);
            currentChoice++;
            selectIcon[currentChoice].SetActive(true);
        }
        else
        {
            selectIcon[currentChoice].SetActive(false);
            currentChoice = 0;
            selectIcon[currentChoice].SetActive(true);
        }
    }

    private void IconUpArrow()
    {
        if (currentChoice > 0)
        {
            selectIcon[currentChoice].SetActive(false);
            currentChoice--;
            selectIcon[currentChoice].SetActive(true);
        }
        else
        {
            selectIcon[currentChoice].SetActive(false);
            currentChoice = maxChoice - 1;
            selectIcon[currentChoice].SetActive(true);
        }
    }
}
