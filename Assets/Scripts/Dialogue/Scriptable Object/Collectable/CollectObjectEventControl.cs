using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollectObjectEventControl : MonoBehaviour
{
    public static Action OnHandlerCollectObject;
    public static Action<Transform> OnInteractObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectable collectableScript = collision.gameObject.GetComponent<ICollectable>();
        IInteractable interactScript = collision.gameObject.GetComponent<IInteractable>();

        if (collectableScript != null)
        {
            OnHandlerCollectObject += collectableScript.AddObject;   
        }     
        if (interactScript != null)
        {
            OnInteractObject += interactScript.SetPositionInteract;
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ICollectable collectableScript = collision.gameObject.GetComponent<ICollectable>();
        IInteractable interactScript = collision.gameObject.GetComponent<IInteractable>();

        if (collectableScript != null)
        {
            OnHandlerCollectObject -= collectableScript.AddObject;
        }
        if (interactScript != null)
        {
            OnInteractObject -= interactScript.SetPositionInteract;
        }
    }  
}
