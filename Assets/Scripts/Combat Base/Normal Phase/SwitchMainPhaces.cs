using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMainPhaces : MonoBehaviour
{
    [SerializeField] private GameObject normalPhase, combatPhase;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            normalPhase.SetActive(false);
            combatPhase.SetActive(true);
        }
    }
}
