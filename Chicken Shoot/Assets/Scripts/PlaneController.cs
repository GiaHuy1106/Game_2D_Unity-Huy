using System.Data;
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
        OnMouseDrag();
    }

    void PlaneMovement() // Move with keyboard
    {
        /*Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.linearVelocity = moveInput * speed;*/
    }

    private void OnMouseDrag()
    {
        // Move with mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition.normalized;
        rb.linearVelocity = direction * speed;

        // Plane stop can't go out of screen
        Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -topLeft.x, topLeft.x),
            Mathf.Clamp(transform.position.y, -topLeft.y, topLeft.y),
            0);
    }
}
