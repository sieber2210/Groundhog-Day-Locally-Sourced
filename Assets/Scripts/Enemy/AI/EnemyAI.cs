using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    EnemyController stats;
    Transform target;
    Vector3 startPos;
    Vector3 roamPos;
    bool isAlive = true;

    private void Start()
    {
        stats = GetComponent<EnemyController>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = stats.stats.speed;
        startPos = transform.position;
        roamPos = startPos + GetRandomRoamPos();
        agent.SetDestination(roamPos);

        StartCoroutine(StateMachine());
    }

    private void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        stats.anim.SetFloat("Locomotion", speedPercent, stats.stats.animationSmoothDamp, Time.deltaTime);
    }

    IEnumerator StateMachine()
    {
        while (isAlive)
        {
            if(target == null)
            {
                IdleRoam();
                yield return new WaitForSeconds(stats.stats.thoughtTime);
                Idle();
            }
            else
            {
                if (Vector3.Distance(transform.position, target.position) > agent.stoppingDistance) ChaseTarget();
                else AttackTarget();
            }
            yield return null;
        }
    }

    void Idle()
    {
        agent.speed = stats.stats.speed;
        agent.SetDestination(transform.position);
    }

    void IdleRoam()
    {
        startPos = transform.position;
        roamPos = startPos + GetRandomRoamPos();
        agent.SetDestination(roamPos);
    }

    void ChaseTarget()
    {
        agent.SetDestination(target.position);
        agent.speed = stats.stats.chaseSpeed;
    }

    void AttackTarget()
    {
        stats.Attack(target.gameObject);
        agent.speed = stats.stats.speed;
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
