using UnityEngine;
using UnityEngine.UIElements;

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

    void ShootBall()
    {
        if (ballShoot.transform.childCount != 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            Vector3 direction = (mousePos - ballShoot.transform.GetChild(0).position).normalized;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
