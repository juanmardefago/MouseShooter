using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryWeaponPart : MonoBehaviour {

    public DamageInstance damage;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    public Transform weaponTip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FireWeapon()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;
        PlayerBulletScript bulletScript = bullet.GetComponent<PlayerBulletScript>();
        bulletScript.speed = bulletSpeed;
        bulletScript.velocity = weaponTip.up;
        bulletScript.SetDamageInstance(damage.Copy());
    }
}
