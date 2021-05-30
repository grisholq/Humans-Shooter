using UnityEngine;

public class Test : MonoBehaviour
{ 
    [SerializeField] private Animator animator;
    [SerializeField] private Transform hand;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.Play("Shooting");
        }
    }
}
