using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "LevelGen/Level")]
public class Level_SO : ScriptableObject
{
    public Texture2D[] maps;
    public ColorToPrefab_SO[] colorToPrefabs;
    public int[] ySpawns;
}
