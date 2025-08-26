using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float speed;
    public SpriteRenderer sprite;
    public Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlaneMovement();
    }

    void PlaneMovement()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.linearVelocity = moveInput * speed;
    }
}
