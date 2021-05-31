using UnityEngine;

[RequireComponent(typeof(HumanMover))]
public class HumanAnimatorController : MonoBehaviour
{
    private Animator animator;
    private HumanMover mover;

    [SerializeField] private string speedName;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        mover = GetComponent<HumanMover>();
    }

    private void Update()
    {
        animator.SetFloat(speedName, mover.Speed);
    }
}
