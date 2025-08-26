using UnityEngine;

public class shoot : MonoBehaviour
{
    public SpriteRenderer Bullet;
    void Start()
    {

    }


    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, transform.position, transform.rotation);
            Debug.Log("Pew Pew");
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Chicken"))
        {
            Destroy(other.gameObject); // Destroy the chicken
            Destroy(Bullet.gameObject);
        }
    }
}
