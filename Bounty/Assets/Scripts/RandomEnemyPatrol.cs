using UnityEngine;
using UnityEngine.AI;

public class RandomEnemyPatrol : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] float range;

    Vector3 centrePoint;

    void Awake()
    {
       agent = GetComponent<NavMeshAgent>(); 
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
            Vector3 point;
            if (RandomPoint(centrePoint, range, out point))
            {
               agent.SetDestination(point);
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
