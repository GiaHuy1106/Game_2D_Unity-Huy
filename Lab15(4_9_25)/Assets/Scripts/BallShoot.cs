using UnityEngine;

public class BallShoot : MonoBehaviour
{
    public GameObject ballShoot, ballReload;
    void Start()
    {
        reloadBall();
    }

    public void reloadBall()
    {
        GameObject ball = BallController.instance.getRandomBall();
        ball.transform.parent = ballShoot.transform;
        ball.transform.localPosition = Vector3.zero;
        Debug.Log("Ball color: " + ball.tag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
