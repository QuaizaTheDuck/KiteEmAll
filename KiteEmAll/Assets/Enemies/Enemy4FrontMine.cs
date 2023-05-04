using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4FrontMine : EnemyBase
{
    [SerializeField] private float maxHp;
    [SerializeField] private float damage;
    [SerializeField] private float timeToAttack;
    [SerializeField] private float movementSpeed;
    private bool isInContactWithTarget = false;
    private float attackTimer = 0;
    //projectile
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpread = 45;
    [SerializeField] private float projectileSpeed = 10;
    [SerializeField] private float projectileTime = 1;
    [SerializeField] private float homingRange = 0;
    [SerializeField] private float homingAngle = 0;


    private void spawnProjectile(GameObject projectilePrefab, Quaternion fireDirection, float damage, float projectileSpeed, float projectileTime, float homingRange, float homingAngle)
    {
        // ==== !!!!! JESLI ERROR TO SPRAWDZ CZY W spawnedProjectile.GetComponent< XXX > JEST WŁASCIWA WARTOŚĆ
        GameObject spawnedProjectile = Instantiate(projectilePrefab, gameObject.transform.position, fireDirection);
        spawnedProjectile.GetComponent<EnemyDefaultProjectile>().setDefaultProjectileStats(damage, projectileSpeed, projectileTime, homingRange, homingAngle);
    }
    override protected void Die()
    {


        for (int i = 0; i <= (4 / 2) - 1; i++)
        {
            if (i != 0)
            {

                float fireAngle = projectileSpread / 2 + (projectileSpread * i);
                Quaternion fireDirection = transform.rotation * Quaternion.AngleAxis(fireAngle, Vector3.forward);
                spawnProjectile(projectilePrefab, fireDirection, damage, projectileSpeed, projectileTime, homingRange, homingAngle);

                fireDirection = transform.rotation * Quaternion.AngleAxis(-fireAngle, Vector3.forward);
                spawnProjectile(projectilePrefab, fireDirection, damage, projectileSpeed, projectileTime, homingRange, homingAngle);
            }
            else
            {
                float fireAngle = projectileSpread / 2;
                Quaternion fireDirection = transform.rotation * Quaternion.AngleAxis(fireAngle, Vector3.forward);
                spawnProjectile(projectilePrefab, fireDirection, damage, projectileSpeed, projectileTime, homingRange, homingAngle);
                fireDirection = transform.rotation * Quaternion.AngleAxis(-fireAngle, Vector3.forward);
                spawnProjectile(projectilePrefab, fireDirection, damage, projectileSpeed, projectileTime, homingRange, homingAngle);
            }

        }

        Destroy(gameObject);
    }

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
        transform.rotation = Quaternion.LookRotation(Vector3.forward, target.position - transform.position);
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

