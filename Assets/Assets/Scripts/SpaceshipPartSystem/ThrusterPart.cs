using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterPart : MonoBehaviour {

    public float speed;
    public float dodgeDistance;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BoostDodgeLeft(Vector3 lastPos, Transform transformToAdjust)
    {
        Vector3 left = -transformToAdjust.right;
        left.Normalize();
        BoostDodgeToPoint(lastPos, transformToAdjust, left * dodgeDistance);
    }

    public void BoostDodgeRight(Vector3 lastPos, Transform transformToAdjust)
    {
        Vector3 right = transformToAdjust.right;
        right.Normalize();
        BoostDodgeToPoint(lastPos, transformToAdjust, right * dodgeDistance);
    }

    public void BoostDodgeForwards(Vector3 lastPos, Transform transformToAdjust)
    {
        Vector3 forward = transformToAdjust.up;
        forward.Normalize();
        BoostDodgeToPoint(lastPos, transformToAdjust, forward * dodgeDistance);
    }

    public void BoostDodgeBackWards(Vector3 lastPos, Transform transformToAdjust)
    {
        Vector3 backward = -transformToAdjust.up;
        backward.Normalize();
        BoostDodgeToPoint(lastPos, transformToAdjust, backward * dodgeDistance);
    }

    private void BoostDodgeToPoint(Vector3 lastPos, Transform transformToAdjust, Vector3 directionToDodge)
    {
        transformToAdjust.position += directionToDodge;
        AdjustRotationBasedOnLinearDifference(lastPos, transformToAdjust);
    }

    public void AdjustRotationAndPosition(Vector3 lastPos, Transform transformToAdjust, Vector3 targetPosition)
    {
        transformToAdjust.position = Vector3.MoveTowards(transformToAdjust.position, targetPosition, speed * Time.deltaTime);
        if (transformToAdjust.position != targetPosition || IsMouseMoving())
        {
            AdjustRotationBasedOnLinearDifference(lastPos, transformToAdjust);
        }
    }

    private bool IsMouseMoving()
    {
        return Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0;
    }


    private void AdjustRotationBasedOnLinearDifference(Vector3 lastPosition, Transform transformToAdjust)
    {
        Vector2 diff = transformToAdjust.position - lastPosition;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transformToAdjust.rotation = Quaternion.Slerp(transformToAdjust.rotation, Quaternion.Euler(0f, 0f, rot_z - 90), 0.1f);
    }

    public void LookAtTarget(Transform transformToAdjust, Vector3 targetPosition)
    {
        Vector2 diff = targetPosition - transformToAdjust.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transformToAdjust.rotation = Quaternion.Slerp(transformToAdjust.rotation, Quaternion.Euler(0f, 0f, rot_z - 90), 0.1f);
    }
}
