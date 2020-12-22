using UnityEngine;

[CreateAssetMenu(fileName = "New Color Prefab", menuName = "LevelGen/Color to Prefab")]
public class ColorToPrefab_SO : ScriptableObject
{
    public Color color;
    public GameObject prefab;
    public float ySpawnValue;
}
