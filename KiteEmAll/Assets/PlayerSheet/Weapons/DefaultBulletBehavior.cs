using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBulletBehavior : MonoBehaviour
{
    private int projectileDamage;
    private float projectileSpeed;
    private float projectileTime;
    private int projectilePierce;
    //Homing
    private float homingRange;
    private float homingAngle;
    private float lifeTimer = 0;
    //Layer w którym proj szuka celu
    [SerializeField] private LayerMask homingTargetLayer;
    private Transform currentTarget;

    public void setDefaultProjectileStats(
        int projectileDamage,
        float projectileSpeed,
        float projectileTime,
        int projectilePierce,
        float homingRange,
        float homingAngle)
    {
        this.projectileDamage = projectileDamage;
        this.projectileSpeed = projectileSpeed;
        this.projectileTime = projectileTime;
        this.projectilePierce = projectilePierce;
        this.homingRange = homingRange;
        this.homingAngle = homingAngle;
    }
    private Transform FindClosestTarget()
    {
        //tablica celow w danym zasiegu
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, homingRange, homingTargetLayer);

        Transform closestTarget = null;
        float closestDistance = Mathf.Infinity;
        //znajdz najblizszy target
        foreach (Collider2D target in targets)
        {
            float distance = Vector2.Distance(transform.position, target.transform.position);
            //float distance = (transform.position - target.transform.position).sqrMagnitude;
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = target.transform;
            }
        }
        return closestTarget;
    }
    void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= projectileTime)
            Destroy(gameObject);

        if (lifeTimer >= projectileTime / 2)
        {
            float opacity = ((projectileTime - lifeTimer) + 0.5f) / projectileTime;
            Color color = gameObject.GetComponent<SpriteRenderer>().color;
            color.a = opacity;
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }

        if (homingAngle > 0)
        {
            //co X klatek znajdz najbliższy cel
            // jeśli nie ma celu w homing range || obecny target jest poza homing range 
            if (Time.frameCount % 3 == 0)
                if ((currentTarget == null || Vector3.Distance(transform.position, currentTarget.position) > homingRange))
                    currentTarget = FindClosestTarget();
            //jesli masz cel obracaj sie w jego kirunku z predkościa homingAngle/s
            if (currentTarget != null)
            {
                Vector2 direction = (currentTarget.position - transform.position).normalized;
                Quaternion homingDirection = Quaternion.LookRotation(Vector3.forward, direction);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, homingDirection, Time.deltaTime * homingAngle);
            }
        }
        //porusz pocisk przed siebie z predkoscia projectileSpeed
        transform.position += transform.up * projectileSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (projectilePierce > 0)
        {
            DefaultEnemy enemy = hit.GetComponent<DefaultEnemy>();
            if (enemy != null)
            {
                enemy.takeDamage(projectileDamage);
                projectilePierce--;
            }
            if (projectilePierce <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
