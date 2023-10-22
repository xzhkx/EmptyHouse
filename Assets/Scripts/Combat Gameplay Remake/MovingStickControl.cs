using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStickControl : MonoBehaviour
{
    [SerializeField] private RectTransform startPosition, targetPosition;
    [SerializeField] private float moveSpeed;

    [SerializeField] private GameObject entityAttackPhase, hidePhase;    
    private bool isMoving;
    public LayerMask layerMask;

    private void Start()
    {
        isMoving = true;
    }

    private void FixedUpdate()
    {
        if (!isMoving) return;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, moveSpeed);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) ||
            GetComponent<RectTransform>().position.x == targetPosition.transform.position.x)           
        {
            if (GetComponent<RectTransform>().position.x == targetPosition.transform.position.x) Debug.Log("Value EQUALLY");
            isMoving = false;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.back, layerMask);

            IChangePhase changable = hit.collider.GetComponent<IChangePhase>();

            if (changable != null)
            {
                ResetPhase();
                SetPhase();
                changable.ChangePhase();             
            }    
        }    
    }

    private void SetPhase()
    {       
        entityAttackPhase.SetActive(true);       
        hidePhase.SetActive(false);      
    }

    public void ResetPhase()
    {
        isMoving = true;
        gameObject.transform.position = startPosition.position;
    }
}
