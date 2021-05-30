using UnityEngine;

public class DiceFactory : MonoBehaviour
{
    [SerializeField] private Transform prefab;
    [SerializeField] private Transform parent;

    public Dice GetDice()
    {
        return Instantiate(prefab, parent).GetComponent<Dice>();
    }
}