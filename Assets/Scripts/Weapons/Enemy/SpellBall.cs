using UnityEngine;

public class SpellBall : MonoBehaviour
{
    [HideInInspector]public int damage;
    [HideInInspector] public float destroyTime;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = col.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
                player.TakeDamage(damage);
            else
                Debug.LogError("Player has no health system");
            Destroy(gameObject);
        }
    }
}
