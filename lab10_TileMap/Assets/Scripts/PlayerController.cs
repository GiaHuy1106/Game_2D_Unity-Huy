using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerJump();
    }

    private void PlayerMove()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false; // Face right
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true; // Face left
        }
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false; // Prevent double jumping
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Player is grounded when colliding with ground or platform
            Debug.Log("Player is grounded");
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * 0.3f); // Bounce the player up slightly
            Destroy(gameObject); // Destroy player
            GameManager gameManager = FindAnyObjectByType<GameManager>();
            gameManager.GameOver(); // Trigger game over in GameManager
        }

        if (collision.gameObject.CompareTag("MovingObject"))
        {
            transform.SetParent(collision.transform); // Make the player a child of the moving object
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingObject"))
        {
            transform.SetParent(null); // Remove the player from being a child of the object
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            Destroy(collision.gameObject); // Destroy collectible
            GameManager gameManager = FindAnyObjectByType<GameManager>();
            gameManager.AddScore(1); // Add score in GameManager
        }

        if (collision.gameObject.CompareTag("HitBox"))
        {
            Destroy(collision.gameObject);
            Collider2D playerCollider = GetComponent<Collider2D>();
            if (playerCollider != null)
            {
                playerCollider.enabled = false; // Disable the player's collider
            }
        }

    }

}
