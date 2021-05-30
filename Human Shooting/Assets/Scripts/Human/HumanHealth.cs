using System;
using UnityEngine;

public class HumanHealth : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

    //public event Action HumanDied;

    public void Damage(float damage)
    {
        health = Math.Max(0, health - damage);
        if(health <= 0) Die();
    }

    public void Heal(float heal)
    {
        health = Math.Min(health + heal, maxHealth);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}