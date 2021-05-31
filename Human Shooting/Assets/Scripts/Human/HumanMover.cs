using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(HumanData))]
public class HumanMover : MonoBehaviour 
{
    private NavMeshAgent navMeshAgent;

    private HumanData data;

    private Vector3 movePoint;

    private bool hasTeamZoneMovePoint;
    private bool hasCentreZoneMovePoint;

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

        hasTeamZoneMovePoint = false;
        hasCentreZoneMovePoint = false;
    }

    private void Update()
    {
        if (!data.TeamWinning && !hasTeamZoneMovePoint)
        {           
            movePoint = data.TeamZone.GetPointInsideZone();
            movePoint = GetNearestPointOnNavMesh(movePoint);
            hasTeamZoneMovePoint = true;
        }
        
        if (data.TeamWinning && !hasCentreZoneMovePoint)
        {
            movePoint = data.CentreZone.GetPointInsideZone();
            movePoint = GetNearestPointOnNavMesh(movePoint);
            hasCentreZoneMovePoint = true;
        }

        MoveToPoint(movePoint);
    }

    private void MoveToPoint(Vector3 point)
    {
        navMeshAgent.SetDestination(point);

        if (transform.position == point)
        {
            hasTeamZoneMovePoint = false;
            hasCentreZoneMovePoint = false;
        }
    }

    private Vector3 GetNearestPointOnNavMesh(Vector3 position)
    {
        NavMeshHit hit;
        NavMesh.SamplePosition(position, out hit, 2, NavMesh.AllAreas);
        return hit.position;
    }
}