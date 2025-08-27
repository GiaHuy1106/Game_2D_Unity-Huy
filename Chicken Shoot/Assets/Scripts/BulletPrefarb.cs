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
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (transform.position.y > Camera.main.orthographicSize + 1)
        {
            Destroy(gameObject);
        }
    }

}

