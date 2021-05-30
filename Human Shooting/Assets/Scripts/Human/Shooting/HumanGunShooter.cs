using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HumanRotator), typeof(HumanData), typeof(HumanShootTimer))]
public class HumanGunShooter : MonoBehaviour
{
    [SerializeField] private float shootRange;
    [SerializeField] private Transform bulletStartPosition;
    [SerializeField] private Transform bulletsPrefab;
    [SerializeField] private Transform bulletsParent;
    [SerializeField] private float bulletLifetime;
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletSpeed;

    private HumanShootTimer timer;
    private HumanRotator rotator;    
    private HumanData data;

    public bool IsShooting { get; set; }

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
            IsShooting = true;         
            rotator.RotateTowards(data.Target);
            Shoot();
        }
        else
        {
            IsShooting = false;
        }
    }

    private void Shoot()
    {
        if (!timer.Passed) return;

        timer.Restart();

        Bullet bullet = Instantiate(bulletsPrefab, bulletsParent).GetComponent<Bullet>();
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