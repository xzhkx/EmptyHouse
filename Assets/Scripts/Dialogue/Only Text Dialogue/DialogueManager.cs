using UnityEngine;
using TMPro;
using Ink.Runtime;
using System;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private Story currentStory;

    public bool dialogueIsPlaying;
    public bool finishDialogue { get; private set; }

    public static DialogueManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        finishDialogue = true;
    }

    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space) && dialogueIsPlaying)
        {
            ContinueStory();
        }       
    }

    public void EnterDialogue(TextAsset inkJSon)
    {
        dialogueIsPlaying = true;
        finishDialogue = false;

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
        }
        else
        {
            ExitDialogue();
        }
    }

    private void ExitDialogue()
    {
        dialogueIsPlaying = false;
        finishDialogue = true;
        dialoguePanel.SetActive(false);    
        DisableNPCEvent.DisableObjectEvent += DisableGameObject;
    }

    private void DisableGameObject(GameObject objectToDisable)
    {
        objectToDisable.SetActive(false);
    }

    public void ExitDialogueDisable()
    {
        DisableNPCEvent.DisableObjectEvent -= DisableGameObject;
    }
}