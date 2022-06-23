using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    private Vector3 randomSpawnPos;

    private float xRange = 100;

    private float zRange = 100;

    private int enemyCount;

    public static int destroyedEnemyCount;

    public static int level;

    void Start()
    {
        enemyCount = 0;
        destroyedEnemyCount = 0;
        level = 1;
        InvokeRepeating("SpawnEnemy", 1f, 0.1f);
    }


    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void SpawnEnemy()
    {
        if (enemyCount<=50)
        {
            int index = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[index], SpawnPos(), enemyPrefabs[index].transform.rotation);
        }
        
    }

    Vector3 SpawnPos()
    {
        randomSpawnPos = new Vector3(Random.Range(-xRange, xRange), 1, Random.Range(-zRange, zRange));

        return randomSpawnPos;
    }


}
