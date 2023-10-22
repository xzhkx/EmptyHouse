using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItems : MonoBehaviour
{
    [SerializeField] private GameObject normalPhase, itemPhase;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Backspace))
        {
            SetPhase();
        }
    }

    private void SetPhase()
    {
        itemPhase.SetActive(false);
        normalPhase.SetActive(true);
    }
}
