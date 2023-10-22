using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatOptionsManager : MonoBehaviour
{
    public GameObject[] CombatOptions;

    public int currentChoice { get; private set; }

    private void Awake()
    {
        currentChoice = 0;
        CombatOptions[0].SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SetOptionArrowRight();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SetOptionArrowLeft();
        }
    }

    private void SetOptionArrowRight()
    {
        CombatOptions[currentChoice].SetActive(false);

        if (currentChoice + 1 < CombatOptions.Length)
        {
            currentChoice++;
            CombatOptions[currentChoice].SetActive(true);
        }    
        else
        {
            currentChoice = 0;
            CombatOptions[currentChoice].SetActive(true);
        }       
    }    

    private void SetOptionArrowLeft()
    {
        CombatOptions[currentChoice].SetActive(false);

        if (currentChoice - 1 >= 0)
        {
            currentChoice--;
            CombatOptions[currentChoice].SetActive(true);
        }
        else
        {
            currentChoice = CombatOptions.Length - 1;
            CombatOptions[currentChoice].SetActive(true);
        }
    }    
}
