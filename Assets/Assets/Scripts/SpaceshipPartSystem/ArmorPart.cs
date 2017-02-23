using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPart : MonoBehaviour {

    public float maxHealth;
    [SerializeField]
    private float currentHealth;

    [SerializeField]
    public ResistanceInstance resistances;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(DamageInstance damage)
    {
        currentHealth -= resistances.CalculateDamage(damage);
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Trigger explosion effects and then...
        Destroy(transform.parent.gameObject);
    }
}
