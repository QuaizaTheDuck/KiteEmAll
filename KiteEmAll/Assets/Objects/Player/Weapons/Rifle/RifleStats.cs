using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleStats : MonoBehaviour
{
    float timer;
    [SerializeField] GameObject rifleProjectilePrefab;
    [SerializeField] Joystick aimJoystick;
    //RIFLE STATS
    [SerializeField] float timeToFire;
    //PROJECTILE STATS
    public float projectileSpeed = 15;
    public int projectileDamage = 50;
    public float projectileLifeTime = 3;

    void Update()
    {
        if (timer <= timeToFire)
        {
            timer += Time.deltaTime;
            return;
        }
        if (aimJoystick.Horizontal != 0 || aimJoystick.Vertical != 0)
        {
            fireRifleProjectile();
            timer = 0;
        }
    }
    private void fireRifleProjectile()
    {

        GameObject firedProjectile = Instantiate(rifleProjectilePrefab);
        firedProjectile.transform.position = transform.position;
        firedProjectile.transform.rotation = transform.rotation;
        firedProjectile.GetComponent<RifleProjectile>().setProjectileStats(
            projectileSpeed,
            projectileDamage,
            projectileLifeTime
        );
    }
}
