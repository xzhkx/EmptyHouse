using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessDodgeBorder : MonoBehaviour, IChangePhase
{
    [SerializeField] private FearBarControler fearBarControl;

    [SerializeField] private float damageToTake;

    public void ChangePhase()
    {
        fearBarControl.TakeFearDamage(damageToTake);
    }    
}
