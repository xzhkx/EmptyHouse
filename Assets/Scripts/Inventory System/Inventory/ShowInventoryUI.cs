using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    private SelectItemHandler selectItemHandler;

    private void Awake()
    {
        selectItemHandler = GetComponent<SelectItemHandler>();
    }

    private void Update()
    {
        if (DialogueManager.Instance.dialogueIsPlaying || QuestionDialogueManager.Instance.dialogueIsPlaying) return;
        InventoryUIShowcase();   
    }

    private void InventoryUIShowcase()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !inventoryPanel.activeInHierarchy)
        {
            inventoryPanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && inventoryPanel.activeInHierarchy)
        {
            inventoryPanel.SetActive(false);
            selectItemHandler.ResetInventoryPanel();
        }
    }
}
