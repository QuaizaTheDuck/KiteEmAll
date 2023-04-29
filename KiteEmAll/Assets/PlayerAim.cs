using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] Joystick aimJoystick;
    private void Update()
    {
        Debug.DrawRay(transform.position, new Vector2(aimJoystick.Horizontal, aimJoystick.Vertical) * 20, Color.red);
        //rotate Player
        if (aimJoystick.Horizontal != 0 || aimJoystick.Vertical != 0)
            transform.rotation = Quaternion.LookRotation(Vector3.forward, new Vector2(aimJoystick.Horizontal, aimJoystick.Vertical));
    }
}
