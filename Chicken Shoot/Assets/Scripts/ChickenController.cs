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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
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
