using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public float Speed;
    public GameObject egg;

    void Start()
    {

    }

    void Update()
    {
        ChickenMovement();
    }

    void ChickenMovement()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); // Destroy bullet
            Destroy(gameObject); // Destroy chicken
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            Destroy(collision.gameObject); //Destroy Plane
            Destroy(gameObject);
        }
    }
}
