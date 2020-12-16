using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    PlayerMovementInput stats;
    int curHealth;

    private void Start()
    {
        stats = GetComponent<PlayerMovementInput>();

        curHealth = stats.moveStats.maxHealth;
    }

    public void TakeDamage(int amount)
    {
        curHealth -= amount;
        if (curHealth <= 0)
            StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        Debug.Log("Player has died!");
        yield return new WaitForSeconds(3f);
        //currently reloading current scene on death. Replace with actual death system later
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
