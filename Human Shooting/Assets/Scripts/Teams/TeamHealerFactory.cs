using UnityEngine;

public class TeamHealerFactory : MonoBehaviour
{
    [SerializeField] private Transform prefab;
    [SerializeField] private Transform parent;
    [SerializeField] private int healAmount;

    public Healer GetHealer()
    {
        Healer healer = Instantiate(prefab, parent).GetComponent<Healer>();
        healer.Heal = healAmount;
        return healer;
    }
}