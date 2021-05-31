using UnityEngine;

public class Team : MonoBehaviour
{
    [SerializeField] private DiceCannonData cannonData;

    [SerializeField] private TeamHumanFactory humansFactory;
    [SerializeField] private TeamHealerFactory healersFactory;
   
    [SerializeField] private Transform humansParent;
    [SerializeField] private Transform garbageParent;

    [SerializeField] private TeamZone teamZone;
    [SerializeField] private CentreZone centreZone;

    [SerializeField] private Color teamFlagColor;
    [SerializeField] private Color spawnDiceColor;
    [SerializeField] private Color healDiceColor;
    [SerializeField] private int teamId;

    private float teamPoints;

    public float TeamPoints 
    { 
        get
        {
            return teamPoints;
        }

        set
        {
            teamPoints = Mathf.Max(0, value);
        }
    }

    public Transform GarbageParent { get => garbageParent; set => garbageParent = value; }
    public int HumansCount { get => humansParent.childCount; }

    public Color SpawnDiceColor { get => spawnDiceColor; }
    public Color HealDiceColor { get => healDiceColor; }
    public Color TeamFlagColor { get => teamFlagColor; }

    public TeamZone TeamZone { get => teamZone; }

    public HumanData[] Humans
    {
        get
        {
            return humansParent.GetComponentsInChildren<HumanData>();
        }
    }


    private void Awake()
    {
        cannonData.Team = this;
    }

    public void Disable()
    {

    }

    public void SpawnHumans(Vector3 position, int count)
    {
        for (int i = 0; i < count; i++)
        {
            HumanData human = humansFactory.GetHuman();
            human.transform.position = RandomizePosition(position);
            human.TeamZone = teamZone;
            human.CentreZone = centreZone;
            human.GarbageParent = garbageParent;
            human.TeamId = teamId;
        }     
    } 
    
    public void SpawnHeal(Vector3 position, int count)
    {
        Healer healer = healersFactory.GetHealer();
        healer.TeamId = teamId;
        healer.Range = count * 2;
        healer.transform.position = position;
        Destroy(healer.gameObject, 1.3f);
    }

    private Vector3 RandomizePosition(Vector3 position)
    {
        Vector3 newPos = Random.insideUnitSphere * 0.8f + position;
        return new Vector3(newPos.x, position.y, newPos.z);
    }
}