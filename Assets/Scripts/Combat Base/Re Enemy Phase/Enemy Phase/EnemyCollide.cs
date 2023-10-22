using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollide : MonoBehaviour
{
    [SerializeField] private HealthBarController healthBar;
    [SerializeField] GameObject normalPhase, enemyAttackPhase, enemyIcon;
    [SerializeField] private RectTransform playerStartPosition, enemyStartPosition;
    [SerializeField] private EntityUIManager entityUIManager;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyFollow>() != null)
        {
            SetPhase();
            healthBar.TakeHealthDamage(entityUIManager.currentDamageToTake);           
        }
    }

    private void SetPhase()
    {
        normalPhase.SetActive(true);
        ResetPhase();
        enemyAttackPhase.SetActive(false);       
    }

    private void ResetPhase()
    {
        transform.position = playerStartPosition.position;
        enemyIcon.transform.position = enemyStartPosition.position;
    }
}
