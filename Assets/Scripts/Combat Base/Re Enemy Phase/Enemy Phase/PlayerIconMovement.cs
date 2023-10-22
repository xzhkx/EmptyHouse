using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIconMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandlerMovement();
    }

    private void HandlerMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(moveX, moveY).normalized;

        if(moveX == 0 && moveY == 0)
        {
            playerRigidbody.velocity = Vector2.zero;
        }    
        else
        {
            playerRigidbody.velocity = direction * speed;
        }    
    }    
}
