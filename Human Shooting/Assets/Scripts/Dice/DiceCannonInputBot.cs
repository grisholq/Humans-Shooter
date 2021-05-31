using UnityEngine;

[RequireComponent(typeof(DiceCannonData))]
public class DiceCannonInputBot : DiceCannonInput
{
    private DiceCannonData data;

    private void Awake()
    {
        data = GetComponent<DiceCannonData>();
    }

    private void Update()
    {
        ProcessInput();
    }

    public override void ProcessInput()
    {
        if (data.Dice == null) return;

        Vector3 point = data.Team.TeamZone.GetPointInsideZone();
        point.y = 0;

        MoveMouse(point);
        PressMouseButton(point);
    }
}