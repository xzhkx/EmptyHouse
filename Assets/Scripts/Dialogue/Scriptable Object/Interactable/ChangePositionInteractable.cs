using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePositionInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] Transform targetPosition;

    public void SetPositionInteract(Transform objectPositionToMove)
    {
        objectPositionToMove.position = new Vector3(targetPosition.position.x, objectPositionToMove.position.y, objectPositionToMove.position.z);
    }
}
