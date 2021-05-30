using System;
using UnityEngine;

public class HumanHitbox : MonoBehaviour, IHitbox
{
    [SerializeField] private HumanHealth health;
    [SerializeField] private HumanData data;

    public int TeamId 
    {
        get
        {
            return data.TeamId;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ApplyDamage(other.GetComponent<IDamager>());
        ApplyHeal(other.GetComponent<IHealer>());
    }
 
    private void ApplyDamage(IDamager damager)
    {
        if(damager != null && damager.TeamId != data.TeamId)
        {
            health.Damage(damager.Damage);
        }
    }

    private void ApplyHeal(IHealer healer)
    {
        if (healer != null && healer.TeamId != data.TeamId)
        {
            health.Damage(healer.Heal);
        }
    }
}