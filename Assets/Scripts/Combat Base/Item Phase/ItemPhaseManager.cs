using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class ItemPhaseManager : MonoBehaviour
{
    [SerializeField] private InventorySystem inventorySystem;
    [SerializeField] private List<GameObject> itemList = new List<GameObject>();
    private List<GameObject> selectIcon = new List<GameObject>();

    [SerializeField] private GameObject itemPhase, normalPhase;

    private UsingItemHandler usingItemHandler;
    private int currentChoice, maxChoice;

    private void Awake()
    {
        usingItemHandler = GetComponent<UsingItemHandler>();

        foreach (GameObject item in itemList)
        {
            item.SetActive(false);
        }

        for (int i = 0; i < itemList.Count; i++)
        {
            selectIcon.Add(itemList[i].transform.GetChild(0).gameObject);
        }
    }

    private void OnEnable()
    {       
        currentChoice = 0;
        maxChoice = inventorySystem.inventory.Count;
        UpdateInventory();
    }

    private void Update()
    {
        HandlerSelectItem();
    }

    private void HandlerSelectItem()
    {
        if (inventorySystem.inventory.Count == 0) return;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            IconDownArrrow();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            IconUpArrow();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ItemData data = inventorySystem.inventory[currentChoice].itemData;
            if (data.itemID == 10)
            {
                usingItemHandler.AlmondWaterUseItem(data);
                StartCoroutine(SetPhase());
                UpdateInventory();             
            }
        }
    }

    private IEnumerator SetPhase()
    {
        yield return new WaitForSeconds(0.1f);

        normalPhase.SetActive(true);
        itemPhase.SetActive(false);      
    }

    public void UpdateInventory()
    {
        foreach (GameObject item in itemList)
        {
            item.SetActive(false);
        }

        if (inventorySystem.inventory.Count > 0)
        {
            Debug.Log("Update Inventotry");

            for (int i = 0; i < inventorySystem.inventory.Count; i++)
            {
                itemList[i].GetComponent<TextMeshProUGUI>().text =
                    inventorySystem.inventory[i].itemData.displayName;
                itemList[i].SetActive(true);
                itemList[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            itemList[0].transform.GetChild(0).gameObject.SetActive(true);
        }        
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
