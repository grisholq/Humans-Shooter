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
        if (ApplyDamage(other.GetComponent<IDamager>())) Destroy(other.gameObject);
        ApplyHeal(other.GetComponent<IHealer>());
    }
 
    private bool ApplyDamage(IDamager damager)
    {
        if(damager != null && damager.TeamId != data.TeamId)
        {
            health.Damage(damager.Damage);
            return true;
        }

        return false;
    }

    private bool ApplyHeal(IHealer healer)
    {
        if (healer != null && healer.TeamId == data.TeamId)
        {
            health.Heal(healer.Heal);
            return true;
        }

        return false;
    }
}