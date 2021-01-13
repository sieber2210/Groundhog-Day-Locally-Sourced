using UnityEngine;

[CreateAssetMenu(fileName = "New Color Prefab", menuName = "LevelGen/Color to Prefab")]
public class ColorToPrefab_SO : ScriptableObject
{
    public Color32 color;
    public GameObject prefab;
    public float ySpawnValue;
}
