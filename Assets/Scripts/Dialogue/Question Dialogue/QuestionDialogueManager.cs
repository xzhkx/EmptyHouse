using UnityEngine;
using TMPro;
using Ink.Runtime;
using System.Collections.Generic;

public class QuestionDialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private Story currentStory;

    [SerializeField] private GameObject[] UIChoices;
    private List<Choice> inkChoices;

    public bool dialogueIsPlaying;
    public bool isSelectChoice;

    public static QuestionDialogueManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        isSelectChoice = false;

        for (int i = 0; i < 2; i++)
        {
            UIChoices[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && dialogueIsPlaying && !isSelectChoice)
        {
            ContinueStory();
        }
    }

    public void EnterDialogue(TextAsset inkJSon)
    {
        dialogueIsPlaying = true;
        currentStory = new Story(inkJSon.text);
        dialoguePanel.SetActive(true);
        var text = currentStory.Continue();
        dialogText.text = text;
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            var text = currentStory.Continue();
            dialogText.text = text;
            DisplayChoice();
        }
        else
        {
            inkChoices = currentStory.currentChoices;
            if (inkChoices.Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    UIChoices[i].gameObject.SetActive(false);
                    Debug.Log("false");
                }
            }
            ExitDialogue();
        }
    }

    private void ExitDialogue()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void DisplayChoice()
    {
        inkChoices = currentStory.currentChoices;
        if (inkChoices.Count == 0)
        {
            for(int i = 0; i < 2; i++)
            {
                UIChoices[i].gameObject.SetActive(false);
            }
            return;
        }

        isSelectChoice = true;
        int index = 0;

        foreach(Choice currentChoice in inkChoices)
        {
            UIChoices[index].gameObject.SetActive(true);
            UIChoices[index].GetComponentInChildren<TextMeshProUGUI>().text = currentChoice.text;
            index++;
        }
    }

    public void MakeChoice(int index)
    {
        isSelectChoice = false;
        currentStory.ChooseChoiceIndex(index);
        var text = currentStory.Continue();
        ContinueStory();
        inkChoices.Clear();
    } 
}
