using UnityEngine;
using UnityEngine.UIElements;

public class BallShoot : MonoBehaviour
{
    public GameObject ballShoot, ballReload;
    void Start()
    {
        reloadBall();
        changeBallToShootPos();
    }

    public void reloadBall()
    {
        GameObject ball = BallController.instance.getRandomBall();
        ball.transform.parent = ballReload.transform;
        ball.transform.localPosition = Vector3.zero;
    }

    public void changeBallToShootPos()
    {
        GameObject ball = ballReload.transform.GetChild(0).gameObject;
        ball.transform.parent = ballShoot.transform;
        ball.transform.localPosition = Vector3.zero;

        reloadBall();
    }    

    public void ShootBall()
    {
        if (ballShoot.transform.childCount != 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            Vector3 direction = (mousePos - ballShoot.transform.GetChild(0).position).normalized;

            ballShoot.transform.GetChild(0).GetComponent<BallScripts>().Direction = direction;
            ballShoot.transform.GetChild(0).parent = null;

            changeBallToShootPos();
        }
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBall();
        }
    }

    

}
