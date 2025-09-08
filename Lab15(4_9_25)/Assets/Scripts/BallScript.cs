using System.Reflection;
using UnityEngine;

public class BallScripts : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    void Start()
    {

    }

    void Update()
    {
        if (direction != Vector3.zero)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }


}
