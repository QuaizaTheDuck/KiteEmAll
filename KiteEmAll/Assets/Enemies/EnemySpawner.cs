using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyType
{
    public GameObject enemyPrefab;
    public float spawnRate;
}

[System.Serializable]
public class Wave
{
    public List<EnemyType> enemyTypes;
    public float waveTime;
}

public class EnemySpawner : MonoBehaviour
{
    private Transform playerTrasnform;
    public List<Wave> waves;
    private int currentWaveIndex = 0;
    private float waveTimer = 0f;
    bool isSpawning = false;
    private void OnEnable()
    {
        playerTrasnform = transform.parent;
    }
    private void Update()
    {
        if (currentWaveIndex <= waves.Count - 1)
        {
            if (isSpawning == false)
            {
                //Debug.Log("Zaczynamy spawnic");
                foreach (EnemyType enemyType in waves[currentWaveIndex].enemyTypes)
                {
                    StartCoroutine(spawnEnemiesInWave(enemyType));
                }
                isSpawning = true;
                StartCoroutine(waitUntilWaveEnds(waves[currentWaveIndex].waveTime));
            }
        }
        else
        {
            Debug.Log("ENEMY SPAWNER - KoniecFal");
            gameObject.SetActive(false);
        }
    }
    private IEnumerator waitUntilWaveEnds(float duration)
    {
        Debug.Log("ENEMY SPAWNER - Rozpoczynam fale : " + currentWaveIndex);
        yield return new WaitForSeconds(duration);
        Debug.Log("ENEMY SPAWNER - Koniec fali : " + currentWaveIndex);
        currentWaveIndex++;
        isSpawning = false;
    }
    private IEnumerator spawnEnemiesInWave(EnemyType enemyType)
    {

        int coroutineStartWave = currentWaveIndex;

        while (true)
        {
            if (coroutineStartWave != currentWaveIndex)
            {

                yield break;
            }

            InstantiateSetStatsEnemy(enemyType, playerTrasnform, 1);

            yield return new WaitForSeconds(1 / enemyType.spawnRate);
        }
    }
    private void InstantiateSetStatsEnemy(EnemyType enemyType, Transform playerTransform, float statMulti)
    {
        float angle = Random.Range(0f, Mathf.PI * 2f); // Random angle around the circle
        Vector3 spawnPosition = new Vector3(Mathf.Sin(angle) * 25f, Mathf.Cos(angle) * 25f, 0f); // Calculate position on the circle
        spawnPosition += playerTransform.position;

        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        GameObject spawnedEnemy = Instantiate(enemyType.enemyPrefab, spawnPosition, randomRotation); // Use transform.rotation here
        spawnedEnemy.GetComponent<EnemyBase>().SetTargetAndStatMulti(playerTransform, statMulti);
    }

}
