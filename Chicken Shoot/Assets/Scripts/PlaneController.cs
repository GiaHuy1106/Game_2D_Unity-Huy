using System.Collections;
using System.Data;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float speed;
    public SpriteRenderer sprite;
    public Rigidbody2D rb;
    public GameObject[] BulletPrefarb;

    private float[] bulletAngles;
    public int currentIndex = 0; // first choice

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlaneMovement();
        Shoot();
    }


    void PlaneMovement() // Move with keyboard
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.linearVelocity = moveInput.normalized * speed * Time.deltaTime;

        //limit ship move inside the box
        Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -topLeft.x, topLeft.x),
            Mathf.Clamp(transform.position.y, -topLeft.y, topLeft.y),
            0);
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            Instantiate(BulletPrefarb[currentIndex], transform.position, rotation);
        } 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            Debug.Log("hit plane");
            // Destroy(gameObject); //Destroy plane
            // Destroy(collision.gameObject); // Destroy egg
        }

        if (collision.gameObject.CompareTag("Gift"))
        {            
            Debug.Log("hit gift");
            Destroy(collision.gameObject);
        } 
    }

    private IEnumerator AutoShotLevel1()
    {
        while (true)
        {
            ShotAngleLevel1();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void ShotAngleLevel1()
    {
        float[] Angles = { -30f, -15f, 0, 15f, 30f };
        foreach (var angel in Angles)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, angel);
            var bullet = Instantiate(BulletPrefarb[currentIndex = 0], transform.position, rotation);
        }
    }
    
    private IEnumerator AutoShotLevel2()
    {
        while (true)
        {
            ShotAngleLevel2();
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    private void ShotAngleLevel2()
    {
        float[] Angles = { -30f, -15f, 0, 15f, 30f };
        foreach (var angel in Angles)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, angel);
            var bullet = Instantiate(BulletPrefarb[currentIndex = 3], transform.position, rotation);
        }
    }
}
