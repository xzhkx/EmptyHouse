using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    [SerializeField] private GameObject normalPhase;
    [SerializeField] private GameObject enemyAttackPhase;
    [SerializeField] private RectTransform playerStartPosition, enemyStartPosition, enemy, playerIcon;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerIconMovement>() != null)
        {
            SetPhase();
        }
    }

    private void SetPhase()
    {
        enemyAttackPhase.SetActive(false);
        normalPhase.SetActive(true);
        ResetPhase();
    }

    private void ResetPhase()
    {
        playerIcon.transform.position = playerStartPosition.position;
        enemy.transform.position = enemyStartPosition.position;
    }
}
