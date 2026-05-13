using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class RandomEnemyPatrol : MonoBehaviour
{
    [Header("References")]
    EnemyAttack enemyAttack;
    SpiderDroidAttack spiderDroidAttack;
    PlayerHealth playerHealth;
    [SerializeField] private Transform target;
    Animator anim;
    NavMeshAgent agent;
    EnemyHealth enemyHealth;

    [Header("Patrol Settings")]
    [SerializeField] float patrolRange;
    [SerializeField] float waitTime = 2f;
    [SerializeField] float chaseSpeed = 3.5f;
    Vector3 centrePoint;

    bool playerIsSeen;
    bool playerInAttackRange;
    public bool isSpiderDroid;

    [Header("LayerMask Settings")]
    [SerializeField] private LayerMask playerLayer;

    [Header("Decetion Range")]
    [SerializeField] float playerSeenRange = 34f;
    [SerializeField] float playerAttackRange = 28f;

    [Header("Attack Cooldown Settings")]
    [SerializeField] float attackRate = 1f;
    bool attackOnCoolDown;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        enemyAttack = GetComponent<EnemyAttack>();
        spiderDroidAttack = GetComponent<SpiderDroidAttack>();
        enemyHealth = GetComponent<EnemyHealth>();
        playerHealth = FindAnyObjectByType<PlayerHealth>();
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
        if (!playerIsSeen && !playerInAttackRange && !enemyHealth.GetEnemyDamaged())
        {
            Patrol();
            anim.SetBool("isMoving", true);
        }
        else if (playerIsSeen && !playerInAttackRange || enemyHealth.GetEnemyDamaged() == true )
        {
            ChaseTarget();
            anim.SetBool("isMoving", true);
        }
        else if (playerIsSeen && playerInAttackRange && !enemyHealth.GetEnemyDamaged())
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
            agent.speed = chaseSpeed;
            Debug.Log("Player Seen");
        }

    }

    void FireWeapon()
    {
        if (playerHealth.GetPlayerAlive() == true)
        {
            agent.SetDestination(transform.position);
            Debug.Log("Player In Range");
            if (target != null)
            {
               Vector3 targetCenter = new Vector3(target.position.x, target.position.y + 1f, target.position.z);
                transform.LookAt(targetCenter);
            }
            if (!attackOnCoolDown)
            {
                if (isSpiderDroid)
                {
                    spiderDroidAttack.FireBullet();
                }
                if (!isSpiderDroid)
                {
                  enemyAttack.FireBullet();  
                }
                StartCoroutine(AttackCoolDown());
            }
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
            if (waitTime <= 0)
            {
                Vector3 point;
                if (RandomPoint(centrePoint, patrolRange, out point))
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

    public bool GetPlayerInAttackRange()
    {
        return playerInAttackRange;
    }
}
