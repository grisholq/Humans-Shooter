using UnityEngine;

public class Healer : MonoBehaviour, IHealer
{
    [SerializeField] private float healerHeight;

    public float TeamId { get; set; }
    public float Heal { get; set; }
    public float Range
    {
        set
        {
            transform.localScale = new Vector3(value, healerHeight, value);
        }
    }
}