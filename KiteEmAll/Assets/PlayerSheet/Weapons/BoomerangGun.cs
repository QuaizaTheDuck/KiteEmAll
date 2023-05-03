using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangGun : WeaponBase
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float baseHomingAngle = 15;
    private Transform homingTarget = null;
    private void spawnProjectile(Transform homingTarget, GameObject projectilePrefab, Quaternion fireDirection, int damage, float projectileSpeed, float projectileTime, int projectilePierce, float homingRange, float homingAngle, float areaOfEffect)
    {
        GameObject spawnedProjectile = Instantiate(projectilePrefab, gameObject.transform.position, fireDirection);
        spawnedProjectile.GetComponent<BoomerangProjectileBehavior>().setDefaultProjectileStats(homingTarget, damage, projectileSpeed, projectileTime, projectilePierce, homingRange, homingAngle);
    }
    public override void Activate(int damage, int projectileCount, float projectileSpeed, float projectileTime, float projectileSpread, int projectilePierce, float homingRange, float homingAngle, float areaOfEffect)
    {
        if (homingTarget == null)
            homingTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if (projectileCount % 2 == 0)
        {
            for (int i = 0; i <= (projectileCount / 2) - 1; i++)
            {
                if (i != 0)
                {

                    float fireAngle = projectileSpread / 2 + (projectileSpread * i);
                    Quaternion fireDirection = transform.rotation * Quaternion.AngleAxis(fireAngle, Vector3.forward);
                    spawnProjectile(homingTarget, projectilePrefab, fireDirection, damage, projectileSpeed, projectileTime, projectilePierce, homingRange, homingAngle + baseHomingAngle, areaOfEffect);

                    fireDirection = transform.rotation * Quaternion.AngleAxis(-fireAngle, Vector3.forward);
                    spawnProjectile(homingTarget, projectilePrefab, fireDirection, damage, projectileSpeed, projectileTime, projectilePierce, homingRange, homingAngle + baseHomingAngle, areaOfEffect);
                }
                else
                {
                    float fireAngle = projectileSpread / 2;
                    Quaternion fireDirection = transform.rotation * Quaternion.AngleAxis(fireAngle, Vector3.forward);
                    spawnProjectile(homingTarget, projectilePrefab, fireDirection, damage, projectileSpeed, projectileTime, projectilePierce, homingRange, homingAngle + baseHomingAngle, areaOfEffect);
                    fireDirection = transform.rotation * Quaternion.AngleAxis(-fireAngle, Vector3.forward);
                    spawnProjectile(homingTarget, projectilePrefab, fireDirection, damage, projectileSpeed, projectileTime, projectilePierce, homingRange, homingAngle + baseHomingAngle, areaOfEffect);
                }
            }
        }
        if (projectileCount % 2 == 1)
        {
            for (int i = -projectileCount / 2; i <= projectileCount / 2; i++)
            {
                if (i != 0)
                {
                    float fireAngle = projectileSpread * i;
                    Quaternion fireDirection = transform.rotation * Quaternion.AngleAxis(fireAngle, Vector3.forward);
                    spawnProjectile(homingTarget, projectilePrefab, fireDirection, damage, projectileSpeed, projectileTime, projectilePierce, homingRange, homingAngle + baseHomingAngle, areaOfEffect);
                }
                else
                {
                    spawnProjectile(homingTarget, projectilePrefab, transform.rotation, damage, projectileSpeed, projectileTime, projectilePierce, homingRange, homingAngle + baseHomingAngle, areaOfEffect);

                }
            }
        }
    }
}
