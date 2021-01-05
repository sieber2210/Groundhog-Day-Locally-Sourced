using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy_SO stats;

    [HideInInspector]public Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Attack(GameObject victim)
    {
        anim.SetTrigger("Attack");
        PlayerHealth player = victim.GetComponent<PlayerHealth>();
        if(player != null)
        {
            player.TakeDamage(stats.damage);
        }
    }
}
