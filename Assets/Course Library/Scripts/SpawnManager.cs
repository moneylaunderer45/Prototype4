using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab; 

    // Start is called before the first frame update
    void Start()
    {
     Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
     SpawnEnemyWave(waveNumber);
     Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }
    private Vector3 GenerateSpawnPosition()
    {
     float spawnPosX = Random.Range(spawnRange, spawnRange);
     float spawnPosZ = Random.Range(spawnRange, spawnRange);
     Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
     return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
     for (int i = 0; i < enemiesToSpawn; i++)
     {
      Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
     }
    }
    // Update is called once per frame
    void Update()
    {
     if (transform.position.y < -10)
     {
      Destroy(gameObject);
     }
     {
      enemyCount = FindObjectsOfType<Enemycontroller>().Length;
      if (enemyCount ==0)
      {
       waveNumber++; SpawnEnemyWave(waveNumber);
       Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
      }
     }
    }
}
