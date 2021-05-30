using UnityEngine;

public class HumanRotator : MonoBehaviour
{
    public void RotateTowards(Transform transform)
    {
        Vector3 eulers = this.transform.eulerAngles;
        this.transform.LookAt(transform);
        this.transform.eulerAngles = new Vector3(eulers.x, this.transform.eulerAngles.y, eulers.z) ;
    }
}