using UnityEngine;

public class BulletPrefarb : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector2.up * speed * Time.deltaTime);
    }
}
