using UnityEngine;

public class BulletPrefarb : MonoBehaviour
{
    public float speed;
    public GameObject bullets;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3 .up * speed * Time.deltaTime);
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if (transform.position.y > Camera.main.orthographicSize + 1)
        {
            Destroy(gameObject);
        }
    }

}

