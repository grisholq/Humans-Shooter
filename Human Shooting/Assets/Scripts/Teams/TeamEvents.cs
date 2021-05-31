using UnityEngine;
using UnityEngine.Events;

public class TeamEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent TeamWon;

    public void Win()
    {
        TeamWon.Invoke();
    }
}