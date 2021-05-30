using System;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private float stopVelocity;

    public Rigidbody Rigidbody { get; set; }

    public event Action<Vector3, int> DiceRolled;

    public bool Active { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Active = false;
    }

    private void Update()
    {
        if (Rigidbody.velocity.magnitude <= stopVelocity && Active == true)
        {
            if(DiceRolled != null)
            {
                DiceRolled(transform.position, GetRolledNumber());
                Die();
            }               
        }
    }

    private int GetRolledNumber()
    { 
        //x axis
        if (Vector3.Dot(Vector3.up, transform.right) > 0.9f)
        {
            return 4;
        }
        else if (Vector3.Dot(-Vector3.up, transform.right) > 0.9f)
        {
            return 3;
        }

        //y axis
        if (Vector3.Dot(Vector3.up, transform.up) > 0.9f)
        {
            return 2;
        }
        else if(Vector3.Dot(-Vector3.up, transform.up) > 0.9f)
        {
            return 5;
        }
                   
        //z axis
        if(Vector3.Dot(Vector3.up, transform.forward) > 0.9f)
        {
            return 1;
        }
        else if(Vector3.Dot(-Vector3.up, transform.forward) > 0.9f)
        {
            return 6;
        }

        return 10;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}