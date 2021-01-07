using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Enemy_SO stats;

    [HideInInspector]public Animator anim;
    Collider col;
    NavMeshAgent agent;
    EnemyAI ai;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        col = GetComponent<Collider>();
        agent = GetComponent<NavMeshAgent>();
        ai = GetComponent<EnemyAI>();
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

    public void Death()
    {
        col.enabled = false;
        agent.enabled = false;
        ai.enabled = false;
    }
}
