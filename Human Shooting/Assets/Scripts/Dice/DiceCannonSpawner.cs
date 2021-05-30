using UnityEngine;

[RequireComponent(typeof(DiceCannonSpawnTimer), typeof(DiceFactory), typeof(DiceData))]
public class DiceCannonSpawner : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Transform dicePoint;

    private DiceCannonSpawnTimer timer;
    private DiceFactory factory;
    private DiceData data;

    private void Awake()
    {
        timer = GetComponent<DiceCannonSpawnTimer>();
        factory = GetComponent<DiceFactory>();
        data = GetComponent<DiceData>();
    }

    private void Update()
    {
        if(data.Dice == null && timer.Passed)
        {
            SpawnDice();
        }
    }

    private void SpawnDice()
    {
        Dice dice = factory.GetDice();
        dice.transform.position = dicePoint.position;
        dice.DiceRolled += player.SpawnHumans;
        dice.Rigidbody.isKinematic = true;
        dice.Active = false;
        data.Dice = dice;

        /*int chance = Random.Range(0, 1);

        switch(chance)
        {
            case 0:
            SpawnHumanDice();
            break;

            case 1:
            SpawnHealDice();
            break;
        }*/
    }
}