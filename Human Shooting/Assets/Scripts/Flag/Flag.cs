using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Transform flag;
    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;

    public float MinHeight { get => minHeight; }
    public float MaxHeight { get => maxHeight; }

    public void SetHeight(float height)
    {
        height = Mathf.Clamp(height, minHeight, maxHeight);
        Vector3 position = flag.position;
        position.y = height;
        flag.position = position;
    }

    public void SetFlagColor(Color color)
    {
        meshRenderer.material.color = color;
    }
}