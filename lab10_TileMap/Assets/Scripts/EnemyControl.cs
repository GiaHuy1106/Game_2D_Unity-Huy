using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    public Transform pointA;
    public Transform pointB;
    private UnityEngine.Vector3 targetPosition;
    private Rigidbody2D rb;

    private bool isDead = false;

    void Start()
    {
        targetPosition = pointB.position; // Start moving towards point B
    }

    void Update()
    {
        objectMove();
    }

    private void objectMove()
    {
        // Move towards the target position
        transform.position = UnityEngine.Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the object has reached the target position
        if (UnityEngine.Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            if (targetPosition == pointB.position)
            {
                targetPosition = pointA.position; // Switch target position to point A 
            }
            else
            {
                targetPosition = pointB.position; // Switch target position to point B
            }
        }
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        // Chuyển animation Die
        //animator.SetTrigger("Die");

        // Dừng di chuyển
        rb.linearVelocity = Vector2.zero;
        //rb.gravityScale = fallGravity;

        // Tắt collider để không còn va chạm
        Collider2D EnemyCol = GetComponent<Collider2D>();
        if (EnemyCol != null) EnemyCol.enabled = false;

        // Xoá enemy sau 2 giây
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        if (other.gameObject.CompareTag("Player"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * 0.3f);
            Destroy(other.gameObject); // Destroy player
            gameManager.GameOver(); // Trigger game over in GameManager
        }
    }
}
