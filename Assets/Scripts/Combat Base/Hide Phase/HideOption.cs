using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HideOption : MonoBehaviour
{
    [SerializeField] private RectTransform startPosition, targetPosition;
    [SerializeField] private float moveSpeed;
    
    [SerializeField] private FearBarControler fearBarControl;
    [SerializeField] private GameObject hidePhase, enemyAttackPhase;

    private bool canMove;
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        canMove = true;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canMove = false;            
        }

        if(gameObject.GetComponent<RectTransform>().position == targetPosition.transform.position)
        {
            SetPhase();
        }    
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, moveSpeed);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canMove) return;
        if (collision.gameObject.CompareTag("Accessable"))
        {
            SetPhase();
            fearBarControl.TakeFearDamage(35);
            return;
        }    
        if (collision.gameObject.CompareTag("InAccessable"))
        {
            SetPhase();
        }    
    }

    private void SetPhase()
    {
        enemyAttackPhase.SetActive(true);
        hidePhase.SetActive(false);
        ResetPhase();
    }

    private void ResetPhase()
    {
        canMove = true;
        gameObject.transform.position = startPosition.position;
    }    
}
