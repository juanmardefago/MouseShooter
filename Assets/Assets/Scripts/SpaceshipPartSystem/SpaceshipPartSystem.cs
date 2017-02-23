using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipPartSystem : MonoBehaviour {
    
    //every one of these should be a specialized behaviour script
    public PrimaryWeaponPart primaryWeapon;
    public SecondaryWeaponPart secondaryWeapon;
    public ArmorPart armor;
    public ThrusterPart thrusters;

	// Use this for initialization
	void Start () {
		
	}

    public void AdjustRotationAndPosition(Vector3 lastPos, Transform transformToAdjust, Vector3 targetPosition)
    {
        if (thrusters != null)
        {
            thrusters.AdjustRotationAndPosition(lastPos, transformToAdjust, targetPosition);
        }
    }

    public void LookAtTarget(Transform transformToAdjust, Vector3 targetPosition)
    {
        thrusters.LookAtTarget(transformToAdjust, targetPosition);
    }

    public void FirePrimaryWeapon()
    {
        primaryWeapon.FireWeapon();
    }

    public void FireSecondaryWeapon()
    {
        secondaryWeapon.FireWeapon();
    }

    public void TakeDamage(DamageInstance damage)
    {
        armor.TakeDamage(damage);
    }

    public void BoostDodgeLeft(Vector3 lastPos, Transform transformToAdjust)
    {
        thrusters.BoostDodgeLeft(lastPos, transformToAdjust);
    }

    public void BoostDodgeRight(Vector3 lastPos, Transform transformToAdjust)
    {
        thrusters.BoostDodgeRight(lastPos, transformToAdjust);
    }

    public void BoostDodgeForwards(Vector3 lastPos, Transform transformToAdjust)
    {
        thrusters.BoostDodgeForwards(lastPos, transformToAdjust);
    }

    public void BoostDodgeBackWards(Vector3 lastPos, Transform transformToAdjust)
    {
        thrusters.BoostDodgeBackWards(lastPos, transformToAdjust);
    }
}
