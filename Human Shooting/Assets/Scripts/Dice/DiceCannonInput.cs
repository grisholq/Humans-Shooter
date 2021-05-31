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
        ProcessInput();
    }

    public virtual void ProcessInput()
    {
        Vector3 point = CastRayOnGround();
        MoveMouse(point);

        if (Input.GetMouseButtonDown(0))
        {
            PressMouseButton(point);
        }
    }

    private Vector3 CastRayOnGround()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 100, groundLayer, QueryTriggerInteraction.Ignore);
        return hit.point;                
    }

    protected void PressMouseButton(Vector3 position)
    {
        if (MouseButtonDown == null) return;
        MouseButtonDown.Invoke(position);
    }

    protected void MoveMouse(Vector3 position)
    {
        if (MouseMoved == null) return;
        MouseMoved.Invoke(position);
    }
}