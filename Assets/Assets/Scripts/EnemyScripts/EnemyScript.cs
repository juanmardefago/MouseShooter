using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public LayerMask playerLayer;
    public float shootingZoneRadius;
    public float fleeZoneRadius;

    private Transform playerTransform;
    private Vector3 randomVector;
    private Vector3 randomizedPlayerTarget;

    private SpaceshipPartSystem spaceship;

    public float maxAccuracyError;
    public float fireRate;

    private Vector3 lastPos;
    private Quaternion lastRotation;
    private bool shooting;

	// Use this for initialization
	void Start () {
        playerTransform = GameObject.FindWithTag("Player").transform;
        spaceship = GetComponent<SpaceshipPartSystem>();
        lastPos = transform.position;
        randomVector = Vector3.zero;
        shooting = false;
	}
	
	// Update is called once per frame
	void Update () {

        if(playerTransform != null)
        {
            HuntDownPlayer();
        }
        lastPos = transform.position;
	}

    private void HuntDownPlayer()
    {
        if (InsideFleeZone())
        {
            Vector3 awayFromPlayer = transform.position - playerTransform.position;
            awayFromPlayer.Normalize();
            spaceship.AdjustRotationAndPosition(lastPos, transform, transform.position + awayFromPlayer);
        }
        else if (InsideShootingZone())
        {
            if (!shooting)
            {
                StartCoroutine(ShootPlayer());
            }
        }
        else
        {
            spaceship.AdjustRotationAndPosition(lastPos, transform, playerTransform.position);
        }
    }

    private void RandomizeTarget()
    {
        randomVector.x = Random.Range(-maxAccuracyError, maxAccuracyError);
        randomVector.y = Random.Range(-maxAccuracyError, maxAccuracyError);

        randomizedPlayerTarget = playerTransform.position + randomVector;
    }

    private IEnumerator ShootPlayer()
    {
        shooting = true;
        RandomizeTarget();
        do
        {
            lastRotation = transform.rotation;
            spaceship.LookAtTarget(transform, randomizedPlayerTarget);
            yield return new WaitForSeconds(0.01f);
        } while (transform.rotation != lastRotation);

        yield return new WaitForSeconds(0.05f);
        spaceship.FirePrimaryWeapon();
        yield return new WaitForSeconds(fireRate);
        shooting = false;
    }

    private bool InsideShootingZone()
    {
        return Physics2D.OverlapCircle(transform.position, shootingZoneRadius, playerLayer);
    }

    private bool InsideFleeZone()
    {
        return Physics2D.OverlapCircle(transform.position, fleeZoneRadius, playerLayer);
    }
}
