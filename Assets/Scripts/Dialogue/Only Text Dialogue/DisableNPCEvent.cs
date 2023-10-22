using UnityEngine;
using System;


public class DisableNPCEvent : MonoBehaviour
{
    public static event Action<GameObject> DisableObjectEvent;
    public static DisableNPCEvent Instance;
    public GameObject currentDialogueObject;

    private void Awake()
    {
        Instance = this;
    }


    private void Update()
    {
        DisableObjectEvent?.Invoke(currentDialogueObject);
    }
}
