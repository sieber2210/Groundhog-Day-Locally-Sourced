using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Level_SO levelObject;
    public PlayerHUD playerHUD;

    private void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int i = 0; i < levelObject.maps.Length; i++)
        {
            for (int x = 0; x < levelObject.maps[i].width; x++)
            {
                for (int z = 0; z < levelObject.maps[i].height; z++)
                {
                    GenerateTile(x, z, i);
                }
            }
        }
    }

    void GenerateTile(int x, int z, int index)
    {
        Color pixelColor = levelObject.maps[index].GetPixel(x, z);
        if(pixelColor.a == 0f)
        {
            return;
        }

        foreach(ColorToPrefab_SO colorPrefab in levelObject.colorToPrefabs)
        {
            if (colorPrefab.color.Equals(pixelColor))
            {
                Vector3 pos = new Vector3(x * 10f, colorPrefab.ySpawnValue, z * 10f);
                GameObject go = Instantiate(colorPrefab.prefab, pos, Quaternion.identity, transform);
                if (go.CompareTag("Player"))
                {
                    playerHUD.player = go;
                    go.transform.parent = null;
                    playerHUD.playerSet = true;
                }
            }            
        }
    }
}
