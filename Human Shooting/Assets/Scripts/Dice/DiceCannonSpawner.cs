using UnityEngine;

[RequireComponent(typeof(DiceCannonSpawnTimer), typeof(DiceFactory), typeof(DiceCannonData))]
public class DiceCannonSpawner : MonoBehaviour
{
    [SerializeField] private Transform dicePoint;

    private DiceCannonSpawnTimer timer;
    private DiceFactory factory;
    private DiceCannonData data;

    private void Awake()
    {
        timer = GetComponent<DiceCannonSpawnTimer>();
        factory = GetComponent<DiceFactory>();
        data = GetComponent<DiceCannonData>();
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
        dice.Rigidbody.isKinematic = true;       
        dice.Active = false;
        data.Dice = dice;

        int chance = Random.Range(0,10);

        if (chance <= 7)
        {
            dice.DiceRolled += data.Team.SpawnHumans;
            dice.MeshRenderer.material.color = data.Team.SpawnDiceColor;
            
        }
        else
        {
            dice.DiceRolled += data.Team.SpawnHeal;
            dice.MeshRenderer.material.color = data.Team.HealDiceColor;
        }                          
    }
}