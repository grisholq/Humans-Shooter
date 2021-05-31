using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] private Collider zone;

    public virtual Vector3 GetPointInsideZone()
    {
        Vector3 point = new Vector3();

        point.x = Random.Range(-zone.bounds.size.x / 2, zone.bounds.size.x / 2);
        point.y = Random.Range(-zone.bounds.size.y / 2, zone.bounds.size.y / 2);
        point.z = Random.Range(-zone.bounds.size.z / 2, zone.bounds.size.z / 2);

        return transform.position + point;
    }
}