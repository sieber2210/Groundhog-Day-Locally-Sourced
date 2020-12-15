using UnityEngine;

public class Boom : MonoBehaviour
{
    int curHealth;

    private void Start()
    {
        curHealth = 1;
    }

    public void TakeDamage(int amount)
    {
        curHealth -= amount;

        if (curHealth <= 0) Die();

        //Havokk

        //FMODUnity.RuntimeManager.PlayOneShot("event:/damage", transform.position);
    }

    void Die()
    {
        Destroy(gameObject);

        //Havokk

        FMODUnity.RuntimeManager.PlayOneShot("event:/boom", transform.position);
    }
}
