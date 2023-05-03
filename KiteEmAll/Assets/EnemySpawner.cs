using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyType
{
    public GameObject enemyPrefab;
    public int maxEnemyCount;
    public float spawnRate;
    [HideInInspector]
    public int currentEnemyCount; // Track the current number of spawned enemies for this type
}

[System.Serializable]
public class EnemyPool
{
    public List<EnemyType> enemyTypes;
    public float activeTime;
}

public class EnemySpawner : MonoBehaviour
{
    public List<EnemyPool> enemyPools;
    private int currentPoolIndex = 0; // Track the current enemy pool index
    private bool spawningComplete = false; // Check if all enemy pools have been spawned

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (!spawningComplete)
        {
            EnemyPool currentPool = enemyPools[currentPoolIndex];

            foreach (EnemyType enemyType in currentPool.enemyTypes)
            {
                enemyType.currentEnemyCount = 0; // Reset the enemy count for this type

                float timeBetweenSpawns = 1f / enemyType.spawnRate; // Calculate the time between each enemy spawn

                while (enemyType.currentEnemyCount < enemyType.maxEnemyCount)
                {
                    GameObject enemy = Instantiate(enemyType.enemyPrefab, GetRandomPositionInCircle(transform.position, 25f), Quaternion.identity);
                    enemyType.currentEnemyCount++;

                    yield return new WaitForSeconds(timeBetweenSpawns);
                }
            }

            currentPoolIndex++;

            if (currentPoolIndex >= enemyPools.Count)
            {
                spawningComplete = true; // All enemy pools have been spawned
            }
            else
            {
                yield return new WaitForSeconds(currentPool.activeTime);
            }
        }
    }


    private Vector2 GetRandomPositionInCircle(Vector2 center, float radius)
    {
        float angle = Random.Range(0f, 360f);
        Vector2 position;
        position.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        position.y = center.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        return position;
    }
}
