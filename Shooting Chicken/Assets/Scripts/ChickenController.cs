using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public float Speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ChickenMovement();
    }
    
    void ChickenMovement()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;
    }
}
