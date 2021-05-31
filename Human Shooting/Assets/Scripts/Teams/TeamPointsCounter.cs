using UnityEngine;

[RequireComponent(typeof(TeamsData))]
public class TeamPointsCounter : MonoBehaviour
{
    [SerializeField] private float minPoints;
    [SerializeField] private float pointsToWin;
    [SerializeField] private float pointsPerSecond;

    private TeamsData data;

    private void Awake()
    {
        data = GetComponent<TeamsData>();
    }

    private void Update()
    {
        AddWinningPoints(data.GetWinningTeam());
        AddWinningPoints(data.GetLoosingTeam());
    }

    private void AddWinningPoints(Team team)
    {
        team.TeamPoints += Time.deltaTime * pointsPerSecond;
    }
    
    private void RemoveWinningPoints(Team team)
    {
        team.TeamPoints -= Time.deltaTime * pointsPerSecond;
    }
}