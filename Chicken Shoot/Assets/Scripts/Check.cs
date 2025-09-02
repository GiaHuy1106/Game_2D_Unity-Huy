using UnityEngine;

public class Check : MonoBehaviour
{
    public GameObject chickenPrefarb;
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 pos = transform.position + new Vector3(1*i, 0, 0);
            Instantiate(chickenPrefarb, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
