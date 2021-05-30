using UnityEngine;

[RequireComponent(typeof(HumanData))]
public class HumanTargetsSearcher : MonoBehaviour
{
    [SerializeField] private float targetRange;

    private HumanData data;

    private void Awake()
    {
        Application.targetFrameRate = 300;
        data = GetComponent<HumanData>();
    }

    private void Update()
    {
        if (data.Target == null)
        {
            LookForTargets();
        }
    }

    private void LookForTargets()
    {
        FindTarget();
    }

    private void FindTarget()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(targetRange, targetRange, targetRange), Quaternion.identity, 1 << 6, QueryTriggerInteraction.Collide);      

        if (colliders.Length == 0) return;

        for (int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].GetComponent<IHitbox>().TeamId != data.TeamId)
            {
                data.Target = colliders[i].transform;
            }
        }
    }
}