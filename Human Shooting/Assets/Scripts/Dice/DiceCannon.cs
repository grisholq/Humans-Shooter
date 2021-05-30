using UnityEngine;

[RequireComponent(typeof(DiceCannonInput))]
public class DiceCannon : MonoBehaviour
{

    [SerializeField] private float diceVelocity;
    [SerializeField] private float diceAngularVelocity;

    private DiceCannonSpawnTimer timer;
    private DiceFactory factory;

    private void Awake()
    {
        timer = GetComponent<DiceCannonSpawnTimer>();
        factory = GetComponent<DiceFactory>();
    }

    private void Update()
    {
        
    }

    private void ThrowDice(Dice dice)
    {

    }
    /*
    private Dice GetDice()
    {

    }

    private Dice GetHealingDice()
    {
        
    }

    private Dice GetSpawningDice()
    {
        Dice dice = factory.GetDice();
        dice.Rigidbody.
    }*/
}