using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteRotation : MonoBehaviour
{
    [SerializeField] Joystick moveJoystick;
    [SerializeField] Quaternion moveDirection;
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (moveJoystick.Horizontal != 0 || moveJoystick.Vertical != 0)
        {
            moveDirection = Quaternion.LookRotation(Vector3.forward, new Vector2(moveJoystick.Horizontal, moveJoystick.Vertical));
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, moveDirection, Time.deltaTime);
    }
}
