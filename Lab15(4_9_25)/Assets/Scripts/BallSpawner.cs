using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public float ballSize = 0.75f;
    public int NumberOfBallInRow = 8;
    public Vector3 SpawnPos;
    GameObject[,] ListBall;
    int indexRow;

    public float speed = 2f;
    void Start()
    {
        float height, width;
        GetScreenSize(out height, out width);

        SpawnPos = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        SpawnPos.z = 0;

        ListBall = new GameObject[1000, NumberOfBallInRow];

        StartCoroutine(LoopEach5s());
    }

    
    void Update()
    {
        for (int row = 0; row < indexRow; row++)
        {
            for (int col = 0; col < NumberOfBallInRow; col++)
            {
                GameObject ball = ListBall[row, col];
                if (ball != null)
                {
                    ball.transform.position += Vector3.down * speed * Time.deltaTime;
                }
            }
        }
    }

    void GetScreenSize(out float height, out float width)
    {
        height = Camera.main.orthographicSize * 2;
        width = height * Screen.width/Screen.height;
    }

    void SpawnRow()
    {
        Vector3 spawnPos = this.SpawnPos;
        if (indexRow > 0)
        {
            spawnPos.y = ListBall[indexRow - 1, 0].transform.position.y + ballSize;
        }
        else
        {
            spawnPos.y += ballSize;
        }

        // Tính chiều rộng của cả hàng
        float rowWidth = (indexRow % 2 == 0)
            ? NumberOfBallInRow * ballSize
            : (NumberOfBallInRow - 1) * ballSize;

        // Canh giữa toàn màn hình
        spawnPos.x = -rowWidth / 2f + ballSize / 2f;

        if (indexRow % 2 == 0)
        {            
            for (int i = 0; i < NumberOfBallInRow; i++)
            {
                GameObject ballNew = BallController.instance.getRandomBall();
                ballNew.transform.position = spawnPos;
                ListBall[indexRow, i] = ballNew;
                spawnPos.x += ballSize;
            }
        }
        else if (indexRow % 2 == 1)  // hàng lẻ
        {
            for (int i = 0; i < NumberOfBallInRow - 1; i++)
            {
                GameObject ballNew = BallController.instance.getRandomBall();
                ballNew.transform.position = spawnPos;
                ListBall[indexRow, i] = ballNew;
                spawnPos.x += ballSize;
            }  
        }
        indexRow++;
    }

    IEnumerator LoopEach5s()
    {
        while (true)
        {
            SpawnRow();
            yield return new WaitForSeconds(2);
        }
    }
}
