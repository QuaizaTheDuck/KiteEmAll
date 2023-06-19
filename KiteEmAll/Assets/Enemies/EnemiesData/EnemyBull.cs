using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBull : EnemyBase
{
    [SerializeField] private float maxHp;
    [SerializeField] private float damage;
    [SerializeField] private float timeToAttack;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed = 180f;
    private bool isInContactWithTarget = false;
    private float attackTimer = 0;

    private void ApplyStatMulti()
    {
        maxHp *= statMulti;
        damage *= statMulti;
        timeToAttack /= statMulti;
        movementSpeed *= statMulti;

        currentHealth = maxHp;

        isStatMultiApplied = true;
    }

    override protected void Update()
    {
        base.Update();
    }
    private void FixedUpdate()
    {
        if (!isStatMultiApplied)
            ApplyStatMulti();

        if (target != null)
        {
            RotateTowardsTarget();
            if (!isInContactWithTarget)
                MoveForward();
        }
    }

    private void RotateTowardsTarget()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        Quaternion targetDirection = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetDirection, Time.fixedDeltaTime * rotationSpeed);
    }


    private void MoveForward()
    {
        enemyRb.velocity = transform.up * movementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isInContactWithTarget = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isInContactWithTarget)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer > timeToAttack)
            {
                collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
                attackTimer = 0;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInContactWithTarget = false;
            attackTimer = 0;
        }
    }
}

