using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public float ballSize = 0.75f;
    public int NumberOfBallInRow;

    public Vector3 SpawnPos;

    GameObject[,] ListBall;
    int indexRow;
    void Start()
    {
        float height, width;
        GetScreenSize(out height, out width);
        
        NumberOfBallInRow = Mathf.FloorToInt(width / ballSize / 2);

        SpawnPos = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));

        StartCoroutine(LoopEach5s());

        ListBall = new GameObject[1000, NumberOfBallInRow];
    }

    
    void Update()
    {
        
    }

    void GetScreenSize(out float height, out float width)
    {
        height = Camera.main.orthographicSize * 2;
        width = height * Screen.width/Screen.height;
    }   
    
    void SpawnRow()
    {
        Vector3 spawnPos = this.SpawnPos;
        if(indexRow > 0)
        {
            spawnPos.y = ListBall[indexRow - 1, 0].transform.position.y + ballSize;
        }
        else
        {
            spawnPos.y += ballSize;
        }

        if(indexRow % 2 == 0)
        {
            for (int i = 0; i < NumberOfBallInRow; i++)
            {
                GameObject ballNew = BallController.instance.getRandomBall();
                ballNew.transform.position = spawnPos;
                ListBall[indexRow, i] = ballNew;
                spawnPos.x += ballSize;
            }
        }
        else
        {
            spawnPos.x += ballSize / 2;

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
            yield return new WaitForSeconds(5);
        }
    }
}
