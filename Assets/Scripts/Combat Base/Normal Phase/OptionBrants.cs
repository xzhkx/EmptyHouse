using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionBrants : MonoBehaviour
{
    private CombatOptionsManager combatOptionManager;
    [SerializeField] private GameObject normalPhase, hidePhase, infoPhase, itemPhase;

    private void Awake()
    {
        combatOptionManager = GetComponent<CombatOptionsManager>();
    }

    private void Update()
    { 
        if(Input.GetKey(KeyCode.Return))
        {
            switch (combatOptionManager.currentChoice)
            {
                case 0:
                    SetPhase(hidePhase);
                    break;
                case 1:
                    SetPhase(infoPhase);
                    break;
                case 2:
                    SetPhase(itemPhase);
                    break;
            }    
        }    
    }

    private void SetPhase(GameObject phaseToChange)
    {
        normalPhase.SetActive(false);
        phaseToChange.SetActive(true);
    }
}
