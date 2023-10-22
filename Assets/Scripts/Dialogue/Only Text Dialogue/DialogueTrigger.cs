using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSOn;

    private bool playerInRange;

    private void Update()
    {
        if(playerInRange && !DialogueManager.Instance.dialogueIsPlaying 
            && DialogueManager.Instance.finishDialogue)
        //If !DialogueManager.Instance.dialogueIsPlaying then dialogue keeps on repeating.
        {
            DialogueManager.Instance.EnterDialogue(inkJSOn);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            DisableNPCEvent.Instance.currentDialogueObject = transform.parent.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }  
}
