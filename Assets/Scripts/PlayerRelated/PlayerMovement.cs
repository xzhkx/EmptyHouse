using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;

    [SerializeField] float moveSpeed;
    private float moveX;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        moveX = 0;
    }

    private void Update()
    {
        if(DialogueManager.Instance.dialogueIsPlaying || QuestionDialogueManager.Instance.dialogueIsPlaying)
        {
            rigidBody.velocity = Vector2.zero;
            animator.SetBool("isMoving", false);           
        }           
        else
        {
            HandleMovement();
        }    
    }

    private void HandleMovement()
    {
        moveX = 0;

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }

        Vector2 moveDirection = new Vector2(moveX, 0);

        bool isIdle = moveX == 0;

        if (isIdle)
        {
            rigidBody.velocity = Vector2.zero;
            animator.SetBool("isMoving", false);
        }
        else
        {
            rigidBody.velocity = moveDirection * moveSpeed;
            animator.SetBool("isMoving", true);
            animator.SetFloat("MoveX", moveX);
        }
    }    
}
