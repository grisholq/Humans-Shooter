using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera camera;

    [SerializeField] private Transform humanPrefab;
    [SerializeField] private Transform humansParent;
   

    [SerializeField] private Healer healerPrefab;
    [SerializeField] private Transform healerParent;
    [SerializeField] private float healerDuration;

    public void HealHumans(Vector3 position, int range)
    {
        Healer healer = Instantiate(healerPrefab, healerParent);
        healer.Range = range;
        Destroy(healer.gameObject, healerDuration);
    }

    public void SpawnHumans(Vector3 position, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Transform human = Instantiate(humanPrefab, humansParent); ;
            human.position = position;
        }
    }
}