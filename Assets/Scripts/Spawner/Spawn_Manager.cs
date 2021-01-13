using UnityEngine;
using System.Collections.Generic;

public class Spawn_Manager : MonoBehaviour
{
    public Spawn_SO spawnAsset;
    public List<Transform> spawnPoints = new List<Transform>();

    bool canSpawn = false;
    float timeToNextSpawn = 0f;
    int enemyCount;
    int maxCount;

    private void Start()
    {
        if (spawnAsset.randomSpawnCount) maxCount = Random.Range(spawnAsset.spawnCountMin, spawnAsset.spawnCountMax);
        else maxCount = spawnAsset.spawnCount;
    }

    private void Update()
    {
        if (canSpawn)
        {
            if (enemyCount == maxCount) canSpawn = false;
            Spawn();
        }
    }

    void Spawn()
    {
        if(Time.time >= timeToNextSpawn)
        {
            int randIndex = Random.Range(0, spawnPoints.Count);
            timeToNextSpawn = Time.time + spawnAsset.spawnDelay;
            Instantiate(spawnAsset.prefabs[0], spawnPoints[randIndex].position, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f), transform);
            enemyCount++;
        }
    }

    public void AddToSpawnPoints(Transform newSpawn)
    {
        spawnPoints.Add(newSpawn);
    }

    public void SetCanSpawn()
    {
        canSpawn = !canSpawn;
    }
}
