using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : EnemyBase
{
    [SerializeField] private float maxHp;
    [SerializeField] private float damage;
    [SerializeField] private float timeToAttack;
    [SerializeField] private float movementSpeed;
    private float aimingSpeed = 2;
    private bool isInContactWithTarget = false;
    private float attackTimer = 0;
    //projectile
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpread;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileTime;
    [SerializeField] private float homingRange;
    [SerializeField] private float homingAngle;
    bool isAiming = false;


    private void spawnProjectile(GameObject projectilePrefab, Quaternion fireDirection, float damage, float projectileSpeed, float projectileTime, float homingRange, float homingAngle)
    {
        // ==== !!!!! JESLI ERROR TO SPRAWDZ CZY W spawnedProjectile.GetComponent< XXX > JEST WŁASCIWA WARTOŚĆ
        GameObject spawnedProjectile = Instantiate(projectilePrefab, gameObject.transform.position, fireDirection);
        spawnedProjectile.GetComponent<EnemyShooterProjectile>().setDefaultProjectileStats(damage, projectileSpeed, projectileTime, homingRange, homingAngle);
    }
    override protected void Update()
    {
        base.Update();

        if ((target.position - transform.position).magnitude < 7f)
        {
            isAiming = true;
            attackTimer += Time.deltaTime;
            if (attackTimer > timeToAttack)
            {
                spawnProjectile(projectilePrefab, transform.rotation, damage, projectileSpeed, projectileTime, homingRange, homingAngle);
                attackTimer = 0;
                isAiming = false;
            }
        }
    }

    private void ApplyStatMulti()
    {
        maxHp *= statMulti;
        damage *= statMulti;
        timeToAttack /= statMulti;
        movementSpeed *= statMulti;

        aimingSpeed = movementSpeed / 4;
        currentHealth = maxHp;

        isStatMultiApplied = true;
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
        transform.rotation = Quaternion.LookRotation(Vector3.forward, target.position - transform.position);
    }

    private void MoveForward()
    {
        if (isAiming)
            enemyRb.velocity = transform.up * aimingSpeed;
        else
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

