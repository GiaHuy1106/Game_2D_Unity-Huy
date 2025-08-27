using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float spawnRate;
    public GameObject chickenPrefab;
    public float nextSpawnTime;

    void Start()
    {
        //Chicken Spawn
        nextSpawnTime = Time.time + spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        ChickenSpawn();
    }

    void ChickenSpawn()
    {
        if (Time.time >= nextSpawnTime)
        {
            // Sinh đối tượng tại vị trí ngẫu nhiên trên trục x, giữ y và z cố định
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 6f, transform.position.z);
            Instantiate(chickenPrefab, spawnPosition, Quaternion.identity);
            // Cập nhật thời gian sinh tiếp theo
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}
