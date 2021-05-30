using UnityEngine;

[RequireComponent(typeof(DiceCannonInput))]
public class DiceCannonRotator : MonoBehaviour
{
    private DiceCannonInput input;

    private void Awake()
    {
        input = GetComponent<DiceCannonInput>();
        input.MouseMoved += RotateCannonTowards;
    }

    private void Update()
    {
        
    }

    private void RotateCannonTowards(Vector3 position)
    {
        Vector3 eulers = transform.eulerAngles;
        transform.LookAt(position);
        transform.eulerAngles = new Vector3(eulers.x, transform.eulerAngles.y, eulers.z);
    }
}