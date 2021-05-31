using UnityEngine;

public class TeamHumanFactory : MonoBehaviour
{
    [SerializeField] private Transform prefab;
    [SerializeField] private Transform parent;

    public HumanData GetHuman()
    {
        return Instantiate(prefab, parent).GetComponent<HumanData>();
    }
}