using UnityEngine;

[RequireComponent(typeof(HumanMover))]
public class HumanData : MonoBehaviour
{
    [SerializeField] private int teamId;
    
    public int TeamId { get => teamId; set => teamId = value; }
    public Transform Target { get; set; }   
}