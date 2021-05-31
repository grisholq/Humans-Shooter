using UnityEngine;

[RequireComponent(typeof(TeamsData), typeof(TeamsPointsCounter))]
public class TeamsFlagHandler : MonoBehaviour
{
    [SerializeField] private Flag flag;

    private TeamsData data;
    private TeamsPointsCounter counter;

    private void Awake()
    {
        data = GetComponent<TeamsData>();
        counter = GetComponent<TeamsPointsCounter>();
    }

    private void Update()
    {
        Team team = data.GetWinningTeam();
        float height = (team.TeamPoints / counter.PointsToWin) * flag.MaxHeight + flag.MinHeight;

        flag.SetFlagColor(team.TeamFlagColor);
        flag.SetHeight(height);     
    }
}