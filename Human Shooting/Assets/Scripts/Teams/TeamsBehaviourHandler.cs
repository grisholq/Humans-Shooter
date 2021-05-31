
using UnityEngine;

[RequireComponent(typeof(TeamsData))]
public class TeamsBehaviourHandler : MonoBehaviour
{
    private TeamsData data;

    private void Awake()
    {
        data = GetComponent<TeamsData>();
    }

    private void Update()
    {
        ActLikeLooser(data.GetLoosingTeam());       
        ActLikeWinner(data.GetWinningTeam());
    }

    private void ActLikeWinner(Team team)
    {
        SetHumansState(team, true);
    }

    private void ActLikeLooser(Team team)
    {
        SetHumansState(team, false);
    }

    private void SetHumansState(Team team, bool winning)
    {
        if (team.HumansCount <= 0) return;

        HumanData[] humen = team.Humans;

        foreach (var human in humen)
        {
            human.TeamWinning = winning;
        }
    }
}