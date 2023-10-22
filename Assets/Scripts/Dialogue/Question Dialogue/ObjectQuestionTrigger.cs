using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectQuestionTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSOn;

    private bool playerInRange;

    private void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.I))
        {
            HandlerDialogue();
        }    
    }

    private void HandlerDialogue()
    {
        if (!QuestionDialogueManager.Instance.dialogueIsPlaying)
        //If !DialogueManager.Instance.dialogueIsPlaying then dialogue keeps on repeating.
        {
            QuestionDialogueManager.Instance.EnterDialogue(inkJSOn);
        }
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
