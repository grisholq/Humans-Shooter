using System;
using UnityEngine;

public class DiceCannonInput : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    [SerializeField] private int groundLayer;

    public event Action<Vector3> MouseMoved;
    public event Action<Vector3> MouseButtonDown;

    private void Update()
    {
        Vector3 point = CastRayOnGround();
        MouseMoved?.Invoke(point);

        if (Input.GetMouseButtonDown(0))
        {
            MouseButtonDown?.Invoke(point); 
        }
    }

    private Vector3 CastRayOnGround()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 100, groundLayer, QueryTriggerInteraction.Ignore);
        return hit.point;                
    }
}