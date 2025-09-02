using System.Data;
using Unity.Mathematics;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private float gridSize;
    private Vector3 spawnPos;
    public GameObject chickenPrefarb;

    void Start()
    {
        
        float height = Camera.main.orthographicSize * 2;
        float width = height / 2;

        spawnPos = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        spawnPos.x += ((gridSize / 2 + (width / 4)));
        spawnPos.y -= gridSize;
        spawnPos.z = 0;
        spawnChicken(Mathf.FloorToInt(height/2f/gridSize), Mathf.FloorToInt(width/gridSize/1.5f));
    }

    // Update is called once per frame
    void spawnChicken(int row, int numOfChicken)
    {
        Debug.Log("Spawn");
        float x = spawnPos.x;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < numOfChicken; j++)
            {
                spawnPos.x += gridSize;
                GameObject chicken = Instantiate(chickenPrefarb, spawnPos, Quaternion.identity);
            }
            spawnPos.x = x;
            spawnPos.y -= gridSize;
        }
    }
}
