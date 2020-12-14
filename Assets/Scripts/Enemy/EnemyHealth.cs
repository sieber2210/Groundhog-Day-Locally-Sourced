using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    EnemyController enemyStats;

    int curHealth;

    private void Start()
    {
        enemyStats = GetComponent<EnemyController>();

        curHealth = enemyStats.stats.maxHealth;
    }

    public void TakeDamage(int amount)
    {
        curHealth -= amount;
        
        if (curHealth <= 0) Die();

        //Havokk

        FMODUnity.RuntimeManager.PlayOneShot("event:/damage",transform.position);
    }

    void Die()
    {
        Destroy(gameObject);

        //Havokk

        FMODUnity.RuntimeManager.PlayOneShot("event:/die", transform.position);
    }
}
