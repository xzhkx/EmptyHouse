using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputPasswordPanel : MonoBehaviour, ICollectable
{
    [SerializeField] private GameObject inputPasswordPanel;
    [SerializeField] private InputPasswordManager inputPasswordManager;
  
    private void Awake()
    {       
        HidePasswordPanel();
    }

    public void AddObject() //ICollectable
    {
        inputPasswordPanel.SetActive(true);

        inputPasswordManager.ShowPasswordPanel("", "0123456789", 3);
    }
    
    private void HidePasswordPanel()
    {
        inputPasswordPanel.SetActive(false);
    }    

}
