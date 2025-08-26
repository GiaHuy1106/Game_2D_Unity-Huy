using UnityEngine;

public class ChickenSpawn : MonoBehaviour
{
    public GameObject chickenPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(chickenPrefab, transform.position, transform.rotation);
    }
}
