using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangProjectileBehavior : MonoBehaviour
{
    private int projectileDamage;
    private float projectileSpeed;
    private float projectileTime;
    private int projectilePierce;
    //Homing
    private float homingRange = 100;
    private float homingAngle;
    private bool zawraca = false;
    private float lifeTimer = 0;
    //Layer w którym proj szuka celu
    private GameObject player;
    private Transform currentTarget;

    public void setDefaultProjectileStats(
        Transform currentTarget,
        int projectileDamage,
        float projectileSpeed,
        float projectileTime,
        int projectilePierce,
        float homingRange,
        float homingAngle)
    {
        this.currentTarget = currentTarget;
        this.projectileDamage = projectileDamage;
        this.projectileSpeed = projectileSpeed;
        this.projectileTime = projectileTime;
        this.projectilePierce = projectilePierce;
        this.homingRange = homingRange;
        this.homingAngle = homingAngle;
        Destroy(gameObject, 30);
    }

    void Update()
    {
        lifeTimer += Time.deltaTime;

        if (lifeTimer >= projectileTime && !zawraca)
        {
            transform.Rotate(Vector3.forward, 180f);
            zawraca = true;
        }

        if (homingAngle > 0 && zawraca)
        {
            //jesli masz cel obracaj sie w jego kirunku z predkościa homingAngle/s
            if (currentTarget != null)
            {
                Vector2 direction = (currentTarget.position - transform.position).normalized;
                Quaternion homingDirection = Quaternion.LookRotation(Vector3.forward, direction);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, homingDirection, Time.deltaTime * homingAngle);
            }
            transform.position += transform.up * projectileSpeed * (lifeTimer - projectileTime) * Time.deltaTime;
        }
        //porusz pocisk przed siebie z predkoscia projectileSpeed
        if (!zawraca)
            transform.position += transform.up * projectileSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D hit)
    {

        EnemyBase enemy = hit.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            enemy.TakeDamage(projectileDamage);
        }
        if (zawraca)
            if (hit.CompareTag("Player"))
            {
                Destroy(gameObject);
            }

    }
}
