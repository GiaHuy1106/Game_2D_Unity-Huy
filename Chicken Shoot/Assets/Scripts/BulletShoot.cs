using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject[] BulletPrefarb;
    public int currentIndex = 0; // first choice
    public float speed;
    void Start()
    {
        StartCoroutine(AutoShot());
    }


    void Update()
    {

    }

    private IEnumerator AutoShot()
    {
        while (true)
        {
            Shot();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void Shot()
    {
        float[] Angles = { -30f, -15f, 0, 15f, 30f };
        foreach (var angel in Angles)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, angel);
            var bullet = Instantiate(BulletPrefarb[currentIndex], transform.position, rotation);
        }
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Chicken"))
        {
            Destroy(other.gameObject); // Destroy the chicken
            Destroy(gameObject);
        }
    }

    
}
