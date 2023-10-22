using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChoiceInteractEvent : MonoBehaviour
{
    [SerializeField] GameObject[] selectIcon;
    [SerializeField] private Transform player;    
    private int currentChoice;

    private void Start()
    {
        selectIcon[0].SetActive(true); selectIcon[1].SetActive(false);
    }

    private void Update()
    {
        HandlerSelectIcon();
    }

    private void HandlerSelectIcon()
    {
        if(QuestionDialogueManager.Instance.isSelectChoice)
        {          
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                IconDownArrrow();
            }
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                IconUpArrow();
            }   
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
                QuestionDialogueManager.Instance.MakeChoice(currentChoice); 
                if(currentChoice == 0)
                {
                    CollectObjectEventControl.OnHandlerCollectObject?.Invoke();
                    CollectObjectEventControl.OnInteractObject?.Invoke(player);
                }    
                currentChoice = 0;
                selectIcon[0].SetActive(true); selectIcon[1].SetActive(false);
            }               
        }    
    }    

    private void IconDownArrrow()
    {
        if (currentChoice == 0)
        {
            selectIcon[currentChoice].SetActive(false);
            currentChoice++;
            selectIcon[currentChoice].SetActive(true);
        }
        else
        {
            selectIcon[currentChoice].SetActive(false);
            currentChoice = 0;
            selectIcon[currentChoice].SetActive(true);
        }
    }    

    private void IconUpArrow()
    {
        if (currentChoice == 1)
        {
            selectIcon[currentChoice].SetActive(false);
            currentChoice--;
            selectIcon[currentChoice].SetActive(true);
        }
        else
        {
            selectIcon[currentChoice].SetActive(false);
            currentChoice = 1;
            selectIcon[currentChoice].SetActive(true);
        }
    }    
}
