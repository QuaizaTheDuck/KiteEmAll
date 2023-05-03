using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGun : WeaponBase
{
    //Pocisk jakim Strzela broń
    [SerializeField] private GameObject projectilePrefab;

    private void spawnProjectile(GameObject projectilePrefab, Quaternion fireDirection, int damage, float projectileSpeed, float projectileTime, int projectilePierce, float homingRange, float homingAngle, float areaOfEffect)
    {
        // ==== !!!!! JESLI ERROR TO SPRAWDZ CZY W spawnedProjectile.GetComponent< XXX > JEST WŁASCIWA WARTOŚĆ
        GameObject spawnedProjectile = Instantiate(projectilePrefab, gameObject.transform.position, fireDirection);
        spawnedProjectile.GetComponent<BombProjectileBehavior>().setDefaultProjectileStats(damage, projectileSpeed, projectileTime, projectilePierce, homingRange, homingAngle, areaOfEffect);
    }
    public override void Activate(int damage, int projectileCount, float projectileSpeed, float projectileTime, float projectileSpread, int projectilePierce, float homingRange, float homingAngle, float areaOfEffect)
    {
        // WARTOSCI JESZCZE NIE UZYTE - damage,projectileSpeed,projectileTime,projectilePierce
        // MAJA ZOSTAC UZYTE PRZY STOWRZENIU ISTANCJI PROJECTILA I WRZUCONE DO SRODKA
        if (projectileCount % 2 == 0)
        {
            for (int i = 0; i <= (projectileCount / 2) - 1; i++)
            {
                if (i != 0)
                {

                    float fireAngle = projectileSpread / 2 + (projectileSpread * i);
                    Quaternion fireDirection = transform.rotation * Quaternion.AngleAxis(fireAngle, Vector3.forward);
                    spawnProjectile(projectilePrefab, fireDirection, damage, projectileSpeed, projectileTime, projectilePierce, homingRange, homingAngle, areaOfEffect);

                    fireDirection = transform.rotation * Quaternion.AngleAxis(-fireAngle, Vector3.forward);
                    spawnProjectile(projectilePrefab, fireDirection, damage, projectileSpeed, projectileTime, projectilePierce, homingRange, homingAngle, areaOfEffect);
                }
                else
                {
                    float fireAngle = projectileSpread / 2;
                    Quaternion fireDirection = transform.rotation * Quaternion.AngleAxis(fireAngle, Vector3.forward);
                    spawnProjectile(projectilePrefab, fireDirection, damage, projectileSpeed, projectileTime, projectilePierce, homingRange, homingAngle, areaOfEffect);
                    fireDirection = transform.rotation * Quaternion.AngleAxis(-fireAngle, Vector3.forward);
                    spawnProjectile(projectilePrefab, fireDirection, damage, projectileSpeed, projectileTime, projectilePierce, homingRange, homingAngle, areaOfEffect);
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
                    spawnProjectile(projectilePrefab, fireDirection, damage, projectileSpeed, projectileTime, projectilePierce, homingRange, homingAngle, areaOfEffect);
                }
                else
                {
                    spawnProjectile(projectilePrefab, transform.rotation, damage, projectileSpeed, projectileTime, projectilePierce, homingRange, homingAngle, areaOfEffect);

                }
            }
        }
    }
}
