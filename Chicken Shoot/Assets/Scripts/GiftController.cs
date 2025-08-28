using UnityEngine;

public class GiftController : MonoBehaviour
{
    public float Speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        giftMovement();
    }

    private void giftMovement()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            Destroy(gameObject);
        }
    }
}
