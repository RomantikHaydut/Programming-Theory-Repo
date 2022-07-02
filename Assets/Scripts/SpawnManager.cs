using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    public GameObject bossPrefab;

    public GameObject experience;

    private Vector3 randomSpawnPos;

    private float xRange = 100;

    private float zRange = 100;

    private int enemyCount;

    private int bossCount;

    public static int destroyedEnemyCount;

    public static int level;

    void Start()
    {
        bossCount = 0;
        enemyCount = 0;
        destroyedEnemyCount = 0;
        level = 1;
        InvokeRepeating("SpawnEnemy", 1f, 0.01f);
    }


    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void SpawnEnemy()
    {
        if (level<=10)
        {
            if (enemyCount <= 50)
            {
                int index = Random.Range(0, enemyPrefabs.Length);
                Instantiate(enemyPrefabs[index], SpawnPos(), enemyPrefabs[index].transform.rotation);
            }
        }
        else if (level>10 && level<=25)
        {
            if (enemyCount <= 100)
            {
                int index = Random.Range(0, enemyPrefabs.Length);
                Instantiate(enemyPrefabs[index], SpawnPos(), enemyPrefabs[index].transform.rotation);
            }
        }
        else if (level>25)
        {
            if (bossCount <= 5)
            {
                Instantiate(bossPrefab, SpawnPos(), bossPrefab.transform.rotation);
                bossCount++;
            }
            if(enemyCount<=25)
            {
                int index = Random.Range(0, enemyPrefabs.Length);
                Instantiate(enemyPrefabs[index], SpawnPos(), enemyPrefabs[index].transform.rotation);
            }
        }
        
        
    }

    Vector3 SpawnPos()
    {
        randomSpawnPos = new Vector3(Random.Range(-xRange, xRange), 1, Random.Range(-zRange, zRange));

        return randomSpawnPos;
    }

    public void SpawnExperience(Vector3 spawnPos)
    {
        Instantiate(experience, spawnPos, experience.transform.rotation);
    }


}
