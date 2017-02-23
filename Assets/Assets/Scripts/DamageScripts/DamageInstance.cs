using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DamageInstance {

    public float normalDamage;
    public float penetration;
    public float fireDamage;
    public float lightningDamage;
    public float iceDamage;

    private GameObject projectile;

    public DamageInstance(float normalDamage, float penetration, float fireDamage, float lightningDamage, float iceDamage)
    {
        this.normalDamage = normalDamage;
        this.penetration = penetration;
        this.fireDamage = fireDamage;
        this.lightningDamage = lightningDamage;
        this.iceDamage = iceDamage;
    }

    public void DestroyProjectile()
    {
        if(projectile != null)
        {
            GameObject.Destroy(projectile);
        }
    }

    public void SetProjectile(GameObject projectile)
    {
        this.projectile = projectile;
    }

    public DamageInstance Copy()
    {
        return new DamageInstance(normalDamage, penetration, fireDamage, lightningDamage, iceDamage);
    }
}
