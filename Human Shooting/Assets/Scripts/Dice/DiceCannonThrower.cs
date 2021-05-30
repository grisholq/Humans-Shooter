using UnityEngine;

[RequireComponent(typeof(DiceCannonInput), typeof(DiceData), typeof(DiceCannonSpawnTimer))]
public class DiceCannonThrower : MonoBehaviour
{
    [SerializeField] private Transform parent;

    [SerializeField] private float diceVelocity;
    [SerializeField] private float diceAngularVelocity;

    [SerializeField] private float additionalY;

    private DiceCannonInput input;
    private DiceData data;
    private DiceCannonSpawnTimer timer;

    private void Awake()
    {
        input = GetComponent<DiceCannonInput>();
        data = GetComponent<DiceData>();
        timer = GetComponent<DiceCannonSpawnTimer>();

        input.MouseButtonDown += ThrowDice;
    }

    private void ThrowDice(Vector3 position)
    {
        timer.Restart();
        Dice dice = data.Dice;
        data.Dice = null;
        dice.Active = true;
       
        Vector3 direciton = (position - transform.position).normalized;
        direciton.y += additionalY;

        dice.Rigidbody.isKinematic = false;
        dice.Rigidbody.velocity = direciton * diceVelocity;
        dice.Rigidbody.angularVelocity = Random.insideUnitSphere * diceAngularVelocity;        
        dice.transform.parent = parent;
    }
}