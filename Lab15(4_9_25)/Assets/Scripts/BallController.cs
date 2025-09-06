using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController instance;
    public List<GameObject> ballLists;
    void Awake()
    {
        instance = this;
    }

    void Update()
    {

    }

    public GameObject getRandomBall()
    {
        return Instantiate(ballLists[Random.Range(0,ballLists.Count)], Vector3.zero, new Quaternion());
    }
}
