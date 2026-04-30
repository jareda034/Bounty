using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class RandomEnemyPatrol : MonoBehaviour
{
    [Header("Ref")]
    EnemyAttack enemyAttack;
    [SerializeField] private Transform target;
    Animator anim;
    NavMeshAgent agent;

    [Header("Patrol Settings")]
    [SerializeField] float patrolRange;
    [SerializeField] float waitTime = 2f;
    Vector3 centrePoint;

    bool playerIsSeen;
    bool playerInAttackRange;

    [Header("LayerMask Settings")]
    [SerializeField] private LayerMask playerLayer;

    [Header("Decetion Range")]
    [SerializeField] float playerSeenRange = 20f;
    [SerializeField] float playerAttackRange = 15f;

    [Header("Attack Cooldown Settings")]
    [SerializeField] float attackRate = 1f;
    bool attackOnCoolDown;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        enemyAttack = GetComponent<EnemyAttack>();
        centrePoint = agent.transform.position;
        GetTarget();
    }

    void GetTarget()
    {
        if (target == null)
        {
            GameObject player = GameObject.Find("Player");
            if (player != null)
            {
                target = player.transform;
            }
        }
    }

    void Update()
    {
        EnemyBehaviour();
        DetectPlayer();
    }

    void EnemyBehaviour()
    {
        if (!playerIsSeen && !playerInAttackRange)
        {
            Patrol();
            anim.SetBool("isMoving", true);
        }
        else if (playerIsSeen && !playerInAttackRange)
        {
            ChaseTarget();
            anim.SetBool("isMoving", true);
        }
        else if (playerIsSeen && playerInAttackRange)
        {
            FireWeapon();
            anim.SetBool("isMoving", false);
        }
    }

    void ChaseTarget()
    {
        if (target != null)
        {
            agent.SetDestination(target.transform.position);
            Debug.Log("Player Seen");
        }

    }

    void FireWeapon()
    {
        agent.SetDestination(transform.position);
        Debug.Log("Player In Range");
        if (target != null)
        {
            transform.LookAt(target);
        }
        if (!attackOnCoolDown)
        {
           enemyAttack.FireBullet(); 
           StartCoroutine(AttackCoolDown());
        }
    }

    IEnumerator AttackCoolDown()
    {
        attackOnCoolDown = true;
        anim.SetTrigger("isShooting");
        yield return new WaitForSeconds(attackRate);
        attackOnCoolDown = false;
    }

    void DetectPlayer()
    {
        playerIsSeen = Physics.CheckSphere(transform.position, playerSeenRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, playerAttackRange, playerLayer);
    }

    void Patrol()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            waitTime -= Time.deltaTime;
            anim.SetBool("isLooking", true);
            Vector3 point;
            if (RandomPoint(centrePoint, patrolRange, out point))
            {
                if (waitTime <= 0)
                {
                    agent.SetDestination(point);
                    anim.SetBool("isLooking", false);
                    waitTime = 2f;
                }
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
