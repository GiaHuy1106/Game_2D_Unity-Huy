using UnityEngine;

public class Spawn : MonoBehaviour
{
    private float gridSize;
    private Vector3 spawnPos;
    private GameObject chickenPrefarb;

    void Start()
    {
        float height = Camera.main.orthographicSize * 2;
        float width = height / 2;

        spawnPos = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
