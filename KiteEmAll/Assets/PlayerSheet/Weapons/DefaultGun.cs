using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGun : WeaponBase
{
    //Pocisk jakim Strzela broń
    [SerializeField] private GameObject projectilePrefab;
    /*
                                                                         USTAW W PREFABIE
    [SerializeField] protected float baseWeaponDamage = 80;
    [SerializeField] protected float addedDamageEffectiveness = 1;
    [SerializeField] protected float activationCooldown = 1;
    [SerializeField] protected int baseProjectileCount = 1;
    [SerializeField] protected float addedProjectileEffectiveness = 1;
    [SerializeField] protected float baseProjectileSpeed = 15;
    [SerializeField] protected float baseProjectileTime = 2;
    [SerializeField] protected float baseProjectileSpread = 10;
    [SerializeField] protected int baseProjectilePierce = 0;
    */
    // WARTOSCI JESZCZE NIE UZYTE - damage,projectileSpeed,projectileTime,projectilePierce
    // MAJA ZOSTAC UZYTE PRZY STOWRZENIU ISTANCJI PROJECTILA I WRZUCONE DO SRODKA
    private void spawnProjectile(Quaternion fireDirection, int damage, float projectileSpeed, float projectileTime, int projectilePierce)
    {
        GameObject spawnedProjectile = Instantiate(projectilePrefab, gameObject.transform.position, fireDirection);
        spawnedProjectile.GetComponent<DefaultBulletBehavior>().setDefaultProjectileStats(damage, projectileSpeed, projectileTime, projectilePierce);
    }
    public override void Activate(int damage, int projectileCount, float projectileSpeed, float projectileTime, float projectileSpread, int projectilePierce)
    {
        // WARTOSCI JESZCZE NIE UZYTE - damage,projectileSpeed,projectileTime,projectilePierce
        // MAJA ZOSTAC UZYTE PRZY STOWRZENIU ISTANCJI PROJECTILA I WRZUCONE DO SRODKA
        if (projectileCount % 2 == 0)
        {
            for (int i = 0; i <= (projectileCount / 2) - 1; i++)
            {
                Debug.Log("Parzyste " + i);
                if (i != 0)
                {

                    float fireAngle = projectileSpread / 2 + (projectileSpread * i);
                    Quaternion fireDirection = transform.rotation * Quaternion.AngleAxis(fireAngle, Vector3.forward);
                    spawnProjectile(fireDirection, damage, projectileSpeed, projectileTime, projectilePierce);

                    fireDirection = transform.rotation * Quaternion.AngleAxis(-fireAngle, Vector3.forward);
                    spawnProjectile(fireDirection, damage, projectileSpeed, projectileTime, projectilePierce);
                }
                else
                {
                    float fireAngle = projectileSpread / 2;
                    Quaternion fireDirection = transform.rotation * Quaternion.AngleAxis(fireAngle, Vector3.forward);
                    spawnProjectile(fireDirection, damage, projectileSpeed, projectileTime, projectilePierce);
                    fireDirection = transform.rotation * Quaternion.AngleAxis(-fireAngle, Vector3.forward);
                    spawnProjectile(fireDirection, damage, projectileSpeed, projectileTime, projectilePierce);
                }
            }
        }
        if (projectileCount % 2 == 1)
        {
            for (int i = -projectileCount / 2; i <= projectileCount / 2; i++)
            {
                Debug.Log("Nieparzyste " + i);
                if (i != 0)
                {
                    float fireAngle = projectileSpread * i;
                    Quaternion fireDirection = transform.rotation * Quaternion.AngleAxis(fireAngle, Vector3.forward);
                    spawnProjectile(fireDirection, damage, projectileSpeed, projectileTime, projectilePierce);
                }
                else
                {
                    spawnProjectile(transform.rotation, damage, projectileSpeed, projectileTime, projectilePierce);

                }
            }
        }
    }
}
