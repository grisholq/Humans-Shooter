using UnityEngine;

[RequireComponent(typeof(HumanRotator), typeof(HumanData), typeof(HumanShootTimer))]
public class HumanGunShooter : MonoBehaviour
{
    [SerializeField] private float shootRange;
    [SerializeField] private Transform bulletStartPosition;
    [SerializeField] private Transform bulletsPrefab;
    [SerializeField] private float bulletLifetime;
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletSpeed;

    private HumanShootTimer timer;
    private HumanRotator rotator;    
    private HumanData data;


    private void Awake()
    {
        timer = GetComponent<HumanShootTimer>();
        rotator = GetComponent<HumanRotator>();
        data = GetComponent<HumanData>();
    }

    private void Update()
    {
        if(data.Target != null && TargetInRange())
        {        
            rotator.RotateTowards(data.Target);
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!timer.Passed) return;

        timer.Restart();

        Bullet bullet = Instantiate(bulletsPrefab, data.GarbageParent).GetComponent<Bullet>();
        bullet.transform.position = bulletStartPosition.position;
        bullet.Direction = (data.Target.position - transform.position).normalized;
        bullet.TeamId = data.TeamId;
        bullet.Damage = bulletDamage;
        bullet.Speed = bulletSpeed;
        bullet.Lifetime = bulletLifetime;
        bullet.Shoot();
    }

    private bool TargetInRange()
    {
        return Vector3.Distance(transform.position, data.Target.position) <= shootRange;
    }
}