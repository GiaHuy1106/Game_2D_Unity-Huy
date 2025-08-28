using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float chickenSpawnRate;
    public float giftSpawnRate;
    public GameObject chickenPrefab;
    public GameObject giftPrefab;
    public float spawnAreaWidth = 8f; // Độ rộng vùng sinh (trục x)
    public float spawnAreaHeight = 6f; // Chiều cao vùng sinh (trục y)
    public float nextChickenSpawnTime;
    public float nextGiftSpawnTime;
    public int blood = 3;

    void Start()
    {
        // Khởi tạo thời gian sinh
        nextChickenSpawnTime = Time.time + chickenSpawnRate;
        nextGiftSpawnTime = Time.time + giftSpawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        // Sinh gà ngẫu nhiên
        if (Time.time >= nextChickenSpawnTime)
        {
            ChickenSpawn();
            nextChickenSpawnTime = Time.time + chickenSpawnRate;
        }

        // Sinh quà ngẫu nhiên
        if (Time.time >= nextGiftSpawnTime)
        {
            SpawnRandomGift();
            nextGiftSpawnTime = Time.time + giftSpawnRate;
        }
    }

    private void ChickenSpawn()
    {
        //vị trí tương đương x, y, z
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnAreaWidth, spawnAreaWidth),
            6f,
            transform.position.z);
        Instantiate(chickenPrefab, spawnPosition, Quaternion.identity);
    }

    private void SpawnRandomGift()
    {
        Vector3 spawnPosition = new Vector3(
           Random.Range(-spawnAreaWidth, spawnAreaWidth), // x
            6f, // y
            transform.position.z); // z
        Instantiate(giftPrefab, spawnPosition, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("hit ground");
        }
    }
}
