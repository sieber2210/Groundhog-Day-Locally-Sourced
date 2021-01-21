using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Enemy_SO stats;

    [HideInInspector]public Animator anim;
    Collider col;
    NavMeshAgent agent;
    EnemyAI ai;

    //Havokk
    FMOD.Studio.EventInstance swipe;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        col = GetComponent<Collider>();
        agent = GetComponent<NavMeshAgent>();
        ai = GetComponent<EnemyAI>();

        //Havokk
        swipe = FMODUnity.RuntimeManager.CreateInstance("event:/attack");
    }

    public void Attack(GameObject victim)
    {
        anim.SetTrigger("Attack");
        PlayerHealth player = victim.GetComponent<PlayerHealth>();
        if(player != null)
        {
            player.TakeDamage(stats.damage);
        }

        //Havokk
        //swipe.start();
        //swipe.release();
        FMODUnity.RuntimeManager.PlayOneShot("event:/attack", gameObject.transform.position);
    }

    public void Death()
    {
        col.enabled = false;
        agent.enabled = false;
        ai.enabled = false;
    }
}
