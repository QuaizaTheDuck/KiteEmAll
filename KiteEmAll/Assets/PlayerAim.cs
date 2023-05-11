using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] Joystick aimJoystick;
    private Rigidbody2D rbPlayer;

    private void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (aimJoystick.Horizontal != 0 || aimJoystick.Vertical != 0)
        {
            Vector2 direction = new Vector2(aimJoystick.Horizontal, aimJoystick.Vertical);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rbPlayer.MoveRotation(angle);
        }
    }
}
