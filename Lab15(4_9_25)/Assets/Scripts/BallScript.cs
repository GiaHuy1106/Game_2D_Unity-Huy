using System.Reflection;
using UnityEngine;

public class BallScripts : MonoBehaviour
{
    public Vector3 Direction;
    
    void Start()
    {

    }

    void Update()
    {
        if (Direction != Vector3.zero)
        {
            transform.Translate(Direction * Time.deltaTime * 5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("wall"))
        {
            Debug.Log("hit");
        }    
    }


}
