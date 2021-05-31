using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera camera;

    [SerializeField] private Transform humanPrefab;
    [SerializeField] private Transform humansParent;
    [SerializeField] private Transform humanMaterial;
    [SerializeField] private int teamId;
   
    [SerializeField] private Healer healerPrefab;    
    [SerializeField] private float healerDuration;

    [SerializeField] private Transform garbageParent;

    public void HealHumans(Vector3 position, int range)
    {
        Healer healer = Instantiate(healerPrefab, garbageParent);
        healer.Range = range;
        Destroy(healer.gameObject, healerDuration);
    }

    public void SpawnHumans(Vector3 position, int count)
    {
        for (int i = 0; i < count; i++)
        {
            HumanData human = Instantiate(humanPrefab, humansParent).GetComponent<HumanData>();
            human.TeamId = teamId;
            human.transform.position = RandomizePosition(position);
        }
    }

    private Vector3 RandomizePosition(Vector3 position)
    {
        Vector3 newPos = Random.insideUnitSphere * 0.7f + position;
        return new Vector3(newPos.x, position.y, newPos.z);
    }
}