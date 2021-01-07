using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public enum AIState { Idle, Attack, Chase };
    AIState aIState = AIState.Idle;

    [SerializeField] Transform spellSpawnPos;

    NavMeshAgent agent;
    EnemyController stats;
    Transform target;
    Transform player;
    Vector3 startPos;
    Vector3 roamPos;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        stats = GetComponent<EnemyController>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = stats.stats.speed;
        StartCoroutine(StateMachine());
    }

    private void Update()
    {
        if(aIState == AIState.Chase || aIState == AIState.Idle && stats.anim.GetBool("IsAlive"))
        {
            float speedPercent = agent.velocity.magnitude / agent.speed;
            stats.anim.SetFloat("Locomotion", speedPercent, stats.stats.animationSmoothDamp, Time.deltaTime);
        }
    }

    IEnumerator StateMachine()
    {
        while (stats.anim.GetBool("IsAlive"))
        {
            float dist = 0f;
            switch (aIState)
            {
                case AIState.Idle:
                    Idle(dist);
                    break;

                case AIState.Chase:
                    ChaseTarget(dist);
                    break;

                case AIState.Attack:
                    AttackTarget(dist);
                    break;
            }
            yield return new WaitForSeconds(stats.stats.thoughtTime);
        }
    }

    void Idle(float dist)
    {
        agent.speed = stats.stats.speed;
        dist = Vector3.Distance(player.position, transform.position);
        if (dist <= stats.stats.perceptionRadius)
            aIState = AIState.Chase;
        else if (dist <= stats.stats.attackRange)
            aIState = AIState.Attack;

        float randWanderChance = Random.value;
        if (randWanderChance <= stats.stats.wanderChancePercent)
        {
            startPos = transform.position;
            roamPos = GetRandomRoamPos() + startPos;
            agent.SetDestination(roamPos);
        }
        else
            agent.SetDestination(transform.position);
    }

    void ChaseTarget(float dist)
    {
        agent.speed = stats.stats.chaseSpeed;
        dist = Vector3.Distance(player.position, transform.position);
        if (dist >= stats.stats.perceptionRadius)
            aIState = AIState.Idle;
        else if (dist <= stats.stats.attackRange)
            aIState = AIState.Attack;
        /*
        float randVal = Random.value;
        if (randVal >= stats.stats.chanceToCast && dist <= stats.stats.distFromPlayerToCast)
            StartCoroutine(ChargeSpell());
        */
        agent.SetDestination(player.position);
    }

    void AttackTarget(float dist)
    {
        agent.speed = stats.stats.speed;
                
        if (target != null)
            stats.Attack(target.gameObject);

        dist = Vector3.Distance(player.position, transform.position);
        if (dist >= stats.stats.attackRange && dist >= stats.stats.perceptionRadius)
            aIState = AIState.Idle;
        else
            aIState = AIState.Chase;
    }

    IEnumerator ChargeSpell()
    {
        agent.speed = 0f;
        stats.anim.SetTrigger("CastStart");
        GameObject spell = Instantiate(stats.stats.spellPrefab, spellSpawnPos.position, spellSpawnPos.rotation);
        spell.transform.parent = spellSpawnPos;

        SpellBall ball = spell.GetComponent<SpellBall>();
        ball.damage = stats.stats.spellDamage;
        ball.destroyTime = stats.stats.spellRange;
        yield return new WaitForSeconds(stats.stats.castTime);
        ShootSpell(spell);
    }

    void ShootSpell(GameObject spell)
    {
        stats.anim.SetTrigger("CastEnd");
        Rigidbody rb = spell.GetComponent<Rigidbody>();
        spell.transform.parent = null;
        spell.transform.rotation = transform.rotation;
        rb.AddForce(transform.forward * stats.stats.spellSpeed, ForceMode.Impulse);
        aIState = AIState.Idle;
    }

    Vector3 GetRandomRoamPos()
    {
        float xRoam = Random.Range(stats.stats.minRoamRange, stats.stats.maxHealth);
        float zRoam = Random.Range(stats.stats.minRoamRange, stats.stats.maxHealth);
        return new Vector3(xRoam, transform.position.y, zRoam);
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    public void RemoveTarget()
    {
        target = null;
    }
}
