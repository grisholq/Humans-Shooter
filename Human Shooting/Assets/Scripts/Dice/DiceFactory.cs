using UnityEngine;

[RequireComponent(typeof(DiceCannonData))]
public class DiceFactory : MonoBehaviour
{
    [SerializeField] private Transform prefab;
    [SerializeField] private Transform parent;

    private DiceCannonData data;

    private void Start()
    {
        data = GetComponent<DiceCannonData>();
    }

    public Dice GetDice()
    {
        return Instantiate(prefab, parent).GetComponent<Dice>();     
    }
}