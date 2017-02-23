using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResistanceInstance {

    public float normalResistance;
    public float antiPenetrationArmor;
    public float fireResistance;
    public float lightningResistance;
    public float iceResistance;


    public float CalculateDamage(DamageInstance damage)
    {
        float res = 0;
        damage.penetration -= antiPenetrationArmor;
        res += damage.normalDamage * (1 - normalResistance);
        res += damage.fireDamage * (1 - fireResistance);
        res += damage.iceDamage * (1 - iceResistance);
        res += damage.lightningDamage * (1 - lightningResistance);
        if (damage.penetration <= 0)
        {
            damage.DestroyProjectile();
        }
        return res;
    }

}
