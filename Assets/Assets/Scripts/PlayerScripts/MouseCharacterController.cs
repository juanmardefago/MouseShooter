using UnityEngine;
using System.Collections;

public class MouseCharacterController : MonoBehaviour {

    private Vector3 zFix;
    private Vector3 mousePositionWorld;
    private Vector3 lastPos;
    private Rigidbody2D rBody;

    private SpaceshipPartSystem spaceship;

    // Use this for initialization
    void Start () {
        //Cursor.visible = false;
        zFix = new Vector3(0, 0, 10);
        lastPos = transform.position;
        spaceship = GetComponent<SpaceshipPartSystem>();
        rBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        mousePositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition + zFix);
        spaceship.AdjustRotationAndPosition(lastPos, transform, mousePositionWorld);

        CheckForFire1Input();
        CheckForFire2Input();
        CheckForDodgeInput();

        lastPos = transform.position;
    }

    private void CheckForDodgeInput()
    {
        if (Input.GetButtonDown("DodgeLeft"))
        {
            spaceship.BoostDodgeLeft(lastPos, transform);
        }
        else if (Input.GetButtonDown("DodgeRight"))
        {
            spaceship.BoostDodgeRight(lastPos, transform);
        }
        else if (Input.GetButtonDown("DodgeForwards"))
        {
            spaceship.BoostDodgeForwards(lastPos, transform);
        }
        else if (Input.GetButtonDown("DodgeBackwards"))
        {
            spaceship.BoostDodgeBackWards(lastPos, transform);
        }
    }

    private void CheckForFire1Input()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            spaceship.FirePrimaryWeapon();
        }
    }

    private void CheckForFire2Input()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            spaceship.FireSecondaryWeapon();
        }
    }

    private void LookAt2DMousePosition()
    {
        Vector2 diff = transform.position - lastPos;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, rot_z - 90), 0.1f);
    }

}
