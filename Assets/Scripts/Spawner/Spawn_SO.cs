using UnityEngine;

[CreateAssetMenu(fileName = "New Spawn Asset", menuName = "Spawner/Spawn Asset")]
public class Spawn_SO : ScriptableObject
{
    public GameObject[] prefabs;
    public float spawnDelay;
    public int spawnCount, spawnCountMin, spawnCountMax;
    public bool randomSpawnCount;
}
