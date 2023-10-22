using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private RectTransform startPos;

    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        transform.position = startPos.position;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rigidBody.velocity = direction * speed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;   
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
