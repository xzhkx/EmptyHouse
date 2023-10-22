using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputPasswordManager : MonoBehaviour
{
    private GameObject inputPasswordPanel;
    private TMP_InputField inputField;
    [SerializeField] GameObject door;

    [SerializeField] private string currentPassword; 

    private void Awake()
    {
        inputPasswordPanel = gameObject;
        inputField = inputPasswordPanel.GetComponentInChildren<TMP_InputField>();
    }

    private void Update()
    {
        Debug.Log(inputField.text);
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (inputField.text == currentPassword)
            {
                inputPasswordPanel.SetActive(false);
                door.SetActive(false);
            }

            else inputPasswordPanel.SetActive(false);
        }    
    }

    public void ShowPasswordPanel(string inputString, string validCharacters, int characterLimit)
    {
        inputField.text = inputString;
        inputField.characterLimit = characterLimit;

        inputField.onValidateInput = (string text, int charIndex, char addedChar) =>
        {
            return ValidateChar(validCharacters, addedChar);
        };     
    }

    private char ValidateChar(string validCharacters, char addedChar)
    {
        if (validCharacters.IndexOf(addedChar) != -1) return addedChar;
        else return '\0';
    }    
}
