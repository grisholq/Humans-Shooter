using UnityEngine;

[RequireComponent(typeof(DiceCannonInput), typeof(DiceCannonData), typeof(DiceCannonSpawnTimer))]
public class DiceCannonThrower : MonoBehaviour
{
    [SerializeField] private Transform parent;

    [SerializeField] private float diceVelocity;
    [SerializeField] private float diceAngularVelocity;

    [SerializeField] private float additionalY;

    private DiceCannonInput input;
    private DiceCannonData data;
    private DiceCannonSpawnTimer timer;

    private void Awake()
    {
        input = GetComponent<DiceCannonInput>();
        data = GetComponent<DiceCannonData>();
        timer = GetComponent<DiceCannonSpawnTimer>();

        input.MouseButtonDown += ThrowDice;
    }

    private void ThrowDice(Vector3 position)
    {
        if (data.Dice == null) return;

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