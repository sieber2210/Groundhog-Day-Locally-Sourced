using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyCounter : MonoBehaviour
{
    public static int EnemyCount;
    Spawn_Manager spawner;

    public float nextLevelDelay = 5f;

    private void Start()
    {
        spawner = GetComponent<Spawn_Manager>();
        EnemyCount = spawner.spawnAsset.spawnCount;
    }

    private void Update()
    {
        if(EnemyCount <= 0)
        {
            StartCoroutine(NextLevelCountDown());
        }
    }

    IEnumerator NextLevelCountDown()
    {
        yield return new WaitForSeconds(nextLevelDelay);
        if(SceneManager.GetActiveScene().buildIndex <= 10)
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
