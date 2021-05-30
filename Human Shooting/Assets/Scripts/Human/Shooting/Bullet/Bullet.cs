using UnityEngine;

public class Bullet : MonoBehaviour, IDamager
{
    [SerializeField] private new Rigidbody rigidbody;

    public Vector3 Direction { get; set; }
    public float Speed { get; set; }
    public float TeamId { get; set; }
    public float Damage { get; set; }
    public float Lifetime { get; set; }

    private bool isShoot;
    private float shootTime;

    public void Shoot()
    {
        isShoot = true;
        shootTime = Time.time;
        rigidbody.velocity = Direction * Speed;
    }

    void Update()
    {
        if(isShoot && (Time.time - shootTime) >= Lifetime)
        {
            Destroy(this.gameObject);
        }
    }
}