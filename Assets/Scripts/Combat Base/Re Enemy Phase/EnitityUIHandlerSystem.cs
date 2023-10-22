using UnityEngine;
using System;
using TMPro;

public class EnitityUIHandlerSystem : MonoBehaviour
{
    private ControlCombatFlow currentEntityData;
    [SerializeField] private EntityUIManager entityUIManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentEntityData = collision.GetComponent<ControlCombatFlow>();
        if(currentEntityData != null)
        {
            entityUIManager.SetPhase();
            entityUIManager.dialogueEntity.text = currentEntityData.entityData.entityName;  
            entityUIManager.infoPhase.GetComponentInChildren<TextMeshProUGUI>().text
                = currentEntityData.entityData.entityDescription;

            entityUIManager.currentDamageToTake = currentEntityData.entityData.enityDamage;

            currentEntityData.entityAvatar.SetActive(true);
            currentEntityData.entityAttack.SetActive(true);
            entityUIManager.currentAttackType = currentEntityData.entityAttack;
            collision.gameObject.SetActive(false);
        }   
    }

    public void ExitEnityEncounter()
    {
        if (currentEntityData == null) return;

        currentEntityData.entityAvatar.SetActive(false);
        currentEntityData.entityAttack.SetActive(false);
        currentEntityData = null;
    }
}
