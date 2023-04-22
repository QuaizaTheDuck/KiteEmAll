using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] Rigidbody2D rbPlayer;
    [SerializeField] PlayerStats playerStats;
    //JoyStick
    [SerializeField] Joystick moveJoystick;
    [SerializeField] Joystick aimJoystick;
    Vector2 lastMoveInputDirection;
    //Drift
    ContactPoint2D lastHit;
    private void FixedUpdate()
    {
        float joyDeadzone = 0.5f;
        if (moveJoystick.Horizontal >= joyDeadzone
         || moveJoystick.Horizontal <= -joyDeadzone
         || moveJoystick.Vertical >= joyDeadzone
         || moveJoystick.Vertical <= -joyDeadzone
        )
        {
            lastMoveInputDirection.x = moveJoystick.Horizontal;
            lastMoveInputDirection.y = moveJoystick.Vertical;
            MovePlayer();
        }

        if (aimJoystick.Horizontal != 0 || aimJoystick.Vertical != 0)
        {
            RotatePlayer();
        }

    }
    private void MovePlayer()
    {
        rbPlayer.velocity = lastMoveInputDirection.normalized * playerStats.movementSpeed;
    }
    private void RotatePlayer()
    {
        Vector3 aimVector = Quaternion.Euler(0, 0, 90) * new Vector3(aimJoystick.Horizontal, aimJoystick.Vertical, 0f);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, aimVector);
        //forward to oś Z(blue) głębokość w rzucie top down
        //Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        //right lewo/prawo gry
        //Debug.DrawRay(transform.position, transform.right * 3, Color.red);
        //up gora/dol gry
        //Debug.DrawRay(transform.position, transform.up * 3, Color.green);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D hit = collision.GetContact(0);
        rbPlayer.velocity = Vector2.Reflect(rbPlayer.velocity, hit.normal);
        lastHit = hit;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        ContactPoint2D hit = collision.GetContact(0);
        Vector2 relativeStayContactPointPosition = rbPlayer.position - hit.point;//point	The point of contact between the two colliders in world space.
        rbPlayer.velocity = (Vector2.Reflect(rbPlayer.velocity.normalized, hit.normal) * playerStats.movementSpeed) + (relativeStayContactPointPosition.normalized - hit.normal.normalized * 2 * playerStats.movementSpeed);

    }
}
