using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(HumanData))]
public class HumanMover : MonoBehaviour 
{
    [SerializeField] private float randomMovementRange;
    [SerializeField] private float stopDistance;

    private NavMeshAgent navMeshAgent;

    private HumanData data;

    private Vector3 partolPoint;
    private bool hasPatrolPoint;

    public float Speed
    {
        get
        {
            return (navMeshAgent.velocity.magnitude);
        }
    }

    private void Awake()
    {       
        navMeshAgent = GetComponent<NavMeshAgent>();
        data = GetComponent<HumanData>();

        hasPatrolPoint = false;
    }

    private void Update()
    {

        if (data.Target == null)
        {
            Patrol();
        }
        else
        {
            
            ChaseTarget();
        }
    }

    private void Patrol()
    {
        if (!hasPatrolPoint)
        {
            SetPatrolPoint();
            hasPatrolPoint = true;
        }

        if (hasPatrolPoint) navMeshAgent.SetDestination(partolPoint);

        if(navMeshAgent.velocity == Vector3.zero)
        {
            hasPatrolPoint = false;
        }
    }

    private void ChaseTarget()
    {
        hasPatrolPoint = false;
        navMeshAgent.SetDestination(GetNearestPointOnNavMesh(data.Target.position));

        float distance = Vector3.Distance(transform.position, data.Target.position);

        if (distance < stopDistance)
        {
            navMeshAgent.SetDestination(transform.position);
        }       
    }

    private void SetPatrolPoint()
    {
        Vector3 pos = Random.insideUnitCircle * randomMovementRange;
        NavMeshHit hit;
        NavMesh.SamplePosition(transform.position + new Vector3(pos.x, 0, pos.y), out hit, randomMovementRange, NavMesh.AllAreas);
        partolPoint = hit.position;
    }

    private Vector3 GetNearestPointOnNavMesh(Vector3 position)
    {
        NavMeshHit hit;
        NavMesh.SamplePosition(position, out hit, 2, NavMesh.AllAreas);
        return hit.position;
    }
}