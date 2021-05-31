using UnityEngine;

[RequireComponent(typeof(TeamsData), typeof(TeamEvents))]
public class TeamsPointsCounter : MonoBehaviour
{
    [SerializeField] private float pointsToWin;
    [SerializeField] private float pointsPerSecond;

    private TeamsData data;
    private TeamEvents events;

    public float PointsToWin { get => pointsToWin; }

    private void Awake()
    {
        events = GetComponent<TeamEvents>();
        data = GetComponent<TeamsData>();
    }

    private void Update()
    {
        if (!data.HasWinningTeam) return;

        AddWinningPoints(data.GetWinningTeam());
        RemoveWinningPoints(data.GetLoosingTeam());
    }

    private void AddWinningPoints(Team team)
    {
        team.TeamPoints += Time.deltaTime * pointsPerSecond;
        if(team.TeamPoints >= pointsToWin)
        {
            events.Win();
        }
    }
    
    private void RemoveWinningPoints(Team team)
    {
        team.TeamPoints = 0;
    }
}