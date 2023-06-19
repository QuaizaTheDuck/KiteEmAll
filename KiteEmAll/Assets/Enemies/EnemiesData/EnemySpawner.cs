using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform playerTrasnform;
    private int currentWaveIndex = 0;
    private float waveTimer = 0f;
    [SerializeField] private EnemyWaves enemywaves;
    bool isSpawning = false;
    float timer = 0;
    float statMulti = 1;
    private void OnEnable()
    {
        playerTrasnform = transform.parent;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 300)
            statMulti += 0.001f * Time.deltaTime;
        if (timer > 600)
            statMulti += 0.001f * Time.deltaTime;
        if (timer > 900)
            statMulti += 0.005f * Time.deltaTime;
        //Debug.Log(statMulti);
        if (currentWaveIndex <= enemywaves.waves.Count - 1)
        {
            if (isSpawning == false)
            {
                foreach (EnemyType enemyType in enemywaves.waves[currentWaveIndex].enemyTypes)
                {
                    StartCoroutine(spawnEnemiesInWave(enemyType));
                }
                isSpawning = true;
                StartCoroutine(waitUntilWaveEnds(enemywaves.waves[currentWaveIndex].waveTime));
            }
        }
        else
        {
            //Debug.Log("ENEMY SPAWNER - KoniecFal");
            gameObject.SetActive(false);
        }
    }
    private IEnumerator waitUntilWaveEnds(float duration)
    {
        //Debug.Log("ENEMY SPAWNER - Rozpoczynam fale : " + currentWaveIndex);
        yield return new WaitForSeconds(duration);
        //Debug.Log("ENEMY SPAWNER - Koniec fali : " + currentWaveIndex);
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

            InstantiateSetStatsEnemy(enemyType, playerTrasnform, statMulti);

            yield return new WaitForSeconds(1 / enemyType.spawnRate);
        }
    }
    private void InstantiateSetStatsEnemy(EnemyType enemyType, Transform playerTransform, float statMulti)
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);
        Vector3 spawnPosition = new Vector3(Mathf.Sin(angle) * 25f, Mathf.Cos(angle) * 25f, 0f);
        spawnPosition += playerTransform.position;
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        GameObject spawnedEnemy = Instantiate(enemyType.enemyPrefab, spawnPosition, randomRotation);
        spawnedEnemy.GetComponent<EnemyBase>().SetTargetAndStatMulti(playerTransform, statMulti);
    }

}
