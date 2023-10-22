using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableNPCSubscriber : MonoBehaviour
{
    private void OnDisable()
    {
        DialogueManager.Instance.ExitDialogueDisable();
    }
}
