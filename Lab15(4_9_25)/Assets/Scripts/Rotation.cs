
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        
    }
}
