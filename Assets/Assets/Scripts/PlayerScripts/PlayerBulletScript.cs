using UnityEngine;
using System.Collections;

public class PlayerBulletScript : MonoBehaviour {

    public float speed;
    private Rigidbody2D rBody;
    public Vector2 velocity;
    public float disappearTime;
    private float disappearTimer;
    private DamageInstance damage;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = velocity * speed;
        disappearTimer = disappearTime;
	}

    void Update()
    {
        disappearTimer -= Time.deltaTime;
        if(disappearTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" || other.tag == "Damageable")
        {
            other.SendMessage("TakeDamage", damage);
        }
    }

    public void SetDamageInstance(DamageInstance damage)
    {
        damage.SetProjectile(gameObject);
        this.damage = damage;
    }
}
