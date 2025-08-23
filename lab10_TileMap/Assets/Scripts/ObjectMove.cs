using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private float speed;
    public Transform pointA;
    public Transform pointB;
    private UnityEngine.Vector3 targetPosition;
    private Transform Player;

    void Start()
    {
        targetPosition = pointB.position; // Start moving towards point B
    }

    void Update()
    {
        objectMove();
    }

    private void objectMove()
    {
        // Move towards the target position
        transform.position = UnityEngine.Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the object has reached the target position
        if (UnityEngine.Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            if (targetPosition == pointB.position)
            {
                targetPosition = pointA.position; // Switch target position to point A 
            }
            else
            {
                targetPosition = pointB.position; // Switch target position to point B
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             collision.transform.SetParent(transform); // Remove the player from being a child of the object
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null); // Remove the player from being a child of the object
        }
    }
}
