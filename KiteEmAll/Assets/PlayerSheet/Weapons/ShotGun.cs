using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : WeaponBase
{
    //Pocisk jakim Strzela broń
    [SerializeField] private GameObject projectilePrefab;

    private void spawnProjectile(GameObject projectilePrefab, Quaternion fireDirection, int damage, float projectileSpeed, float projectileTime, int projectilePierce, float homingRange, float homingAngle, float areaOfEffect)
    {
        // ==== !!!!! JESLI ERROR TO SPRAWDZ CZY W spawnedProjectile.GetComponent< XXX > JEST WŁASCIWA WARTOŚĆ
        GameObject spawnedProjectile = Instantiate(projectilePrefab, gameObject.transform.position, fireDirection);
        spawnedProjectile.GetComponent<DefaultBulletBehavior>().setDefaultProjectileStats(damage, projectileSpeed, projectileTime, projectilePierce, homingRange, homingAngle);
    }
    public override void Activate(int damage, int projectileCount, float projectileSpeed, float projectileTime, float projectileSpread, int projectilePierce, float homingRange, float homingAngle, float areaOfEffect)
    {
        for (int i = 0; i < projectileCount; i++)
        {
            float fireAngle = Random.Range(0f, projectileSpread / 2);
            if (Random.Range(1, 3) == 1)
            {
                Quaternion fireDirection = transform.rotation * Quaternion.AngleAxis(-fireAngle, Vector3.forward);
                spawnProjectile(projectilePrefab, fireDirection, damage, projectileSpeed, projectileTime, projectilePierce, homingRange, homingAngle, areaOfEffect);
            }
            else
            {
                Quaternion fireDirection = transform.rotation * Quaternion.AngleAxis(fireAngle, Vector3.forward);
                spawnProjectile(projectilePrefab, fireDirection, damage, projectileSpeed, projectileTime, projectilePierce, homingRange, homingAngle, areaOfEffect);
            }
        }
    }
}