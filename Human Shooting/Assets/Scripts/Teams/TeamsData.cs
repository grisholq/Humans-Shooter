using UnityEngine;

public class TeamsData : MonoBehaviour
{
    [SerializeField] private Team playerTeam;
    [SerializeField] private Team botTeam;

    public Team PlayerTeam { get => playerTeam; }
    public Team BotTeam { get => botTeam;}

    public Team GetWinningTeam()
    {
        if(playerTeam.HumansCount > botTeam.HumansCount)
        {
            return playerTeam;
        }
        return botTeam;   
    }
    
    public Team GetLoosingTeam()
    {
        if (playerTeam.HumansCount > botTeam.HumansCount)
        {
            return botTeam;
        }
        return playerTeam;
    }
}