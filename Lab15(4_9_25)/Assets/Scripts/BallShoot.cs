using UnityEngine;

public class BallShoot : MonoBehaviour
{
    public GameObject ballShoot, ballReload;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shoot();
        direction();
        reloadBall();
    }

    public void reloadBall()
    {
        GameObject ball = BallController.ballController.ballcontroller();
        ball.transform.parent = ballShoot.transform;
        ball.transform.localPosition = Vector3.zero;
    }

    void direction()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector2 direction = (mousePosition - transform.position).normalized;

    }

    void shoot()
    {
        GameObject ball = BallController.ballController.ballcontroller();
        if (Input.GetMouseButtonDown(0))
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            Instantiate(ball, transform.position, rotation);
        }
    }
}
