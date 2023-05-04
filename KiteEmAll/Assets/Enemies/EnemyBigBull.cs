using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigBull : EnemyBase
{
    [SerializeField] private float maxHp;
    [SerializeField] private float damage;
    [SerializeField] private float timeToAttack;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed = 180f;
    private bool isInContactWithTarget = false;
    private float attackTimer = 0;
    bool isCharging = false;
    bool isExecutingCharge = false;
    private void ApplyStatMulti()
    {
        maxHp *= statMulti;
        damage *= statMulti;
        timeToAttack /= statMulti;
        movementSpeed *= statMulti;

        currentHealth = maxHp;

        isStatMultiApplied = true;
    }


    protected override void Update()
    {
        base.Update();

        if (!isCharging && !isExecutingCharge && (target.position - transform.position).magnitude < 6f)
        {
            StartCoroutine(ChargeCoroutine());
        }
    }
    private IEnumerator ChargeCoroutine()
    {
        isCharging = true;
        enemyRb.velocity = transform.up * movementSpeed / 4;
        // Load the charge for 1 second
        yield return new WaitForSeconds(1f);
        isExecutingCharge = true;
        isCharging = false;
        enemyRb.velocity = transform.up * movementSpeed * 3;
        // Start charging at double speed
        // Charge for 2 seconds
        yield return new WaitForSeconds(2f);
        isExecutingCharge = false;
    }
    private void FixedUpdate()
    {
        if (!isStatMultiApplied)
            ApplyStatMulti();

        if (target != null && !isExecutingCharge)
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
        if (!isCharging || !isExecutingCharge)
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

