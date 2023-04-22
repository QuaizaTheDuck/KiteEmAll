using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMenager : MonoBehaviour
{
    //przeciwnicy
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject enemyShooter;
    [SerializeField] GameObject enemyCharger;
    [SerializeField] GameObject enemyBarragerHoming;
    [SerializeField] GameObject enemyAssasin;
    [SerializeField] GameObject enemyDodger;
    //staty spawnera
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;
    [SerializeField] GameObject player;
    float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            timer = spawnTimer;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();
        position += player.transform.position;

        //switch (Random.Range(1, 6))
        switch (1)
        {
            case 1:
                GameObject newEnemy = Instantiate(enemy);
                newEnemy.transform.position = position;
                newEnemy.GetComponent<Enemy>().SetTrarget(player);
                newEnemy.transform.parent = transform;

                break;
            case 2:
                GameObject newEnemyShooter = Instantiate(enemyShooter);
                newEnemyShooter.transform.position = position;
                newEnemyShooter.GetComponent<EnemyShooter>().SetTrarget(player);
                newEnemyShooter.transform.parent = transform;
                break;
            case 3:
                GameObject newEnemyCharger = Instantiate(enemyCharger);
                newEnemyCharger.transform.position = position;
                newEnemyCharger.GetComponent<EnemyCharger>().SetTrarget(player);
                newEnemyCharger.transform.parent = transform;
                break;
            case 4:
                GameObject newEnemyBarragerHoming = Instantiate(enemyBarragerHoming);
                newEnemyBarragerHoming.transform.position = position;
                newEnemyBarragerHoming.GetComponent<EnemyBarragerHoming>().SetTrarget(player);
                newEnemyBarragerHoming.transform.parent = transform;
                break;
            case 5:
                GameObject newEnemyAssasin = Instantiate(enemyAssasin);
                newEnemyAssasin.transform.position = position;
                newEnemyAssasin.GetComponent<EnemyAssasin>().SetTrarget(player);
                newEnemyAssasin.transform.parent = transform;
                break;
            case 6:
                GameObject newEnemyDodger = Instantiate(enemyDodger);
                newEnemyDodger.transform.position = position;
                newEnemyDodger.GetComponent<EnemyDodger>().SetTrarget(player);
                newEnemyDodger.transform.parent = transform;
                break;
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = UnityEngine.Random.value > 0.5 ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {

            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;

        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }

        position.z = 0f; ;

        return position;
    }
}
