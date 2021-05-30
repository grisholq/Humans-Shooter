using UnityEngine;

[RequireComponent(typeof(HumanMover), typeof(HumanGunShooter))]
public class HumanAnimatorController : MonoBehaviour
{
    private Animator animator;

    private HumanMover mover;
    private HumanGunShooter shooter;

    [SerializeField] private string speedName;
    [SerializeField] private string shootName;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        mover = GetComponent<HumanMover>();
        shooter = GetComponent<HumanGunShooter>();
    }

    private void Update()
    {
        animator.SetFloat(speedName, mover.Speed);
        animator.SetBool(shootName, shooter.IsShooting);
    }
}
