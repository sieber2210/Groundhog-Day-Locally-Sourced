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
