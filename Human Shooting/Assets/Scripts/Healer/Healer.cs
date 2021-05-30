using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Healer : MonoBehaviour, IHealer
{
    public float TeamId { get; set; }
    public float Heal { get; set; }
    public float Range
    {
        set
        {
            boxCollider.size = new Vector3(value, value, value);
        }
    }

    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
}