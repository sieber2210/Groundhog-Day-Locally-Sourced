using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Enemy_SO enemyStats;

    int curHealth;

    private void Start()
    {
        curHealth = enemyStats.maxHealth;
    }

    public void TakeDamage(int amount)
    {
        curHealth -= amount;
        if (curHealth <= 0) Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
