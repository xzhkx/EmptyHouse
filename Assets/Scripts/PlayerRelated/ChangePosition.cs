using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    [SerializeField] private Transform positionToMove, targetPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            positionToMove.position = new Vector3(targetPosition.position.x, targetPosition.position.y, positionToMove.position.z);
        }
    }
}
