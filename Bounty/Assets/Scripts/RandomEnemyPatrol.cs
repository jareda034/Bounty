using UnityEngine;
using UnityEngine.AI;

public class RandomEnemyPatrol : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] float range;
    [SerializeField] float waitTime = 2f;

    Vector3 centrePoint;
    Animator anim;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        centrePoint = agent.transform.position;
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            waitTime -= Time.deltaTime;
            anim.SetBool("isLooking", true);
            Vector3 point;
            if (RandomPoint(centrePoint, range, out point))
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
