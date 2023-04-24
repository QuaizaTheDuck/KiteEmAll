using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Joystick movementJoystick;
    private Rigidbody2D rbPlayer;
    public float movementSpeed = 5;

    private void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rbPlayer.velocity = new Vector2(movementJoystick.Horizontal, movementJoystick.Vertical) * movementSpeed;
    }

}
