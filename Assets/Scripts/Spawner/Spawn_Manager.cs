using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public Spawn_SO spawnAsset;
    public Transform[] spawnPoints;

    bool canSpawn;
    float timeToNextSpawn = 0f;
    int enemyCount;
    int maxCount;

    private void Start()
    {
        canSpawn = true;
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
            timeToNextSpawn = Time.time + spawnAsset.spawnDelay;
            Instantiate(spawnAsset.prefabs[0], spawnPoints[0].position, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f), transform);
            enemyCount++;
        }
    }
}
