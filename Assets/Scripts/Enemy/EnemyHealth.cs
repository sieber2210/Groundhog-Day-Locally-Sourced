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
        EnemyCounter.EnemyCount--;
        enemyStats.Death();
        enemyStats.anim.SetBool("IsAlive", false);
        enemyStats.anim.SetTrigger("Death");
        //Havokk
        FMODUnity.RuntimeManager.PlayOneShot("event:/die", transform.position);
        Destroy(gameObject, 15f);
    }
}
