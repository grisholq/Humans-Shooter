using UnityEngine;

[RequireComponent(typeof(HumanMover))]
public class HumanData : MonoBehaviour
{
    [SerializeField] private int teamId;
    [SerializeField] private TeamZone teamZone;
    [SerializeField] private CentreZone centreZone;
    [SerializeField] private Transform garbageParent;
     
    public Transform Target { get; set; }
    public int TeamId { get => teamId; set => teamId = value; }
    public TeamZone TeamZone { get => teamZone; set => teamZone = value; }
    public CentreZone CentreZone { get => centreZone; set => centreZone = value; }
    public Transform GarbageParent { get => garbageParent; set => garbageParent = value; }
    public bool TeamWinning { get; set; }
}