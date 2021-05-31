using UnityEngine;
using System.Collections.Generic;

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
        List<int> indexes = new List<int>(20);

        if (colliders.Length == 0) return;

        for (int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].GetComponent<IHitbox>().TeamId != data.TeamId)
            {
                indexes.Add(i);              
            }
        }

        if (indexes.Count == 0) return;

        int index = Random.Range(0, indexes.Count - 1); 

        data.Target = colliders[indexes[index]].transform;
    }
}