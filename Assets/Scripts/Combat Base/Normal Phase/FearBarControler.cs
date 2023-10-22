using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearBarControler : MonoBehaviour
{
    private Slider fearSlider;
    [SerializeField] MovingStickControl movingStickControl;
    [SerializeField] GameObject normalGameplay, combatGameplay, entityAttackPhase, normalPhase;
    [SerializeField] private EntityUIManager entityUIManager;
    [SerializeField] EnitityUIHandlerSystem entityUIHandlerSystem;

    private void Awake()
    {
        fearSlider = GetComponent<Slider>();
        fearSlider.maxValue = 100;
        fearSlider.value = 100;
    }

    public void TakeFearDamage(float fearAmount)
    {
        fearSlider.value -= fearAmount;
        if(fearSlider.value <= 0)
        {
            SetWinPhase();
        }
    }    

    private void SetWinPhase()
    {
        entityUIManager.currentAttackType.SetActive(false);
        normalGameplay.SetActive(true);
        combatGameplay.SetActive(false);
        movingStickControl.ResetPhase();

        entityAttackPhase.SetActive(false);
        normalPhase.SetActive(true);

        fearSlider.maxValue = 100;
        fearSlider.value = 100;

        entityUIHandlerSystem.ExitEnityEncounter();
    }
}
