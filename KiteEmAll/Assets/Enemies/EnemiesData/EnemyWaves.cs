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

[CreateAssetMenu]
public class EnemyWaves : ScriptableObject
{
    public List<Wave> waves;
}
