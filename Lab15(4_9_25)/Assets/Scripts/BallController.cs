using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController ballController;
    public List<GameObject> ballLists;
     public bool isBallAvailable = false; 

    void Start()
    {
        ballController = this;
    }

    //if ball are not available then dont instantiate
    void Update()
    {
         if (!isBallAvailable) 
        {
            ballcontroller();
            isBallAvailable = true; 
        }
    }

    public GameObject ballcontroller()
    {
        return Instantiate(ballLists[Random.Range(0,ballLists.Count)], Vector3.zero, new Quaternion());
    }
}
