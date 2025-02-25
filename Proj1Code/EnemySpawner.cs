using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public int wave = 1; // Current wave count
    private int enemyCount;

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        while (true) // Infinite loop for continuous waves
        {
            enemyCount = wave; // Set the number of enemies to spawn based on the current wave

            for (int i = 0; i < enemyCount; i++)
            {
                Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity); // Spawn enemy
                yield return new WaitForSeconds(3f); // Wait between spawns
            }

            // Increase the wave number for the next wave
            wave++; 

            yield return new WaitForSeconds(3f); // Wait before starting the next wave
        }
    }
}
