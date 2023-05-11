using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] Joystick movementJoystick;
    private Rigidbody2D rbPlayer;
    private Vector2 direction;

    private void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        //Debug.developerConsoleVisible = true;
    }

    private void FixedUpdate()
    {
        direction = new Vector2(movementJoystick.Horizontal, movementJoystick.Vertical) * playerStats.movementSpeed.Value;
        rbPlayer.velocity = new Vector3(direction.x, direction.y, 0);
    }

}
