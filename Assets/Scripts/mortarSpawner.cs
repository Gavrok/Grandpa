using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mortarSpawner : MonoBehaviour
{
    public GameObject bombPrefab; // Assign the bomb prefab in the Inspector
    public float minSpawnInterval = 1f; // Minimum spawn interval
    public float maxSpawnInterval = 3f; // Maximum spawn interval

    private float timer;
    private float nextSpawnTime;

    void Start()
    {
        ResetSpawnTimer(); // Initialize the timer with a random value
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Check if it's time to spawn the next bomb
        if (timer >= nextSpawnTime)
        {
            SpawnBomb();
            ResetSpawnTimer(); // Reset the timer with a new random value
        }
    }

    void SpawnBomb()
    {
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
    }

    void ResetSpawnTimer()
    {
        // Set the timer to a random value between minSpawnInterval and maxSpawnInterval
        nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
        timer = 0; // Reset the current timer
    }
}
