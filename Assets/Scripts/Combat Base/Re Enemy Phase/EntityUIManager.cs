using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EntityUIManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI dialogueEntity;
    [SerializeField] public GameObject combatPhase, normalPhase, infoPhase;
    public GameObject currentAttackType;
    public float currentDamageToTake;

    public void SetPhase()
    {
        combatPhase.SetActive(true);
        normalPhase.SetActive(false);
    }
}
