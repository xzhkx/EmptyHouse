using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedDodgeBorder : MonoBehaviour, IChangePhase
{
    [SerializeField] private HealthBarController healthBarController;
    [SerializeField] private EntityUIManager entityUIManager;
    
    public void ChangePhase()
    {
        healthBarController.TakeHealthDamage(entityUIManager.currentDamageToTake);
    }    
}
