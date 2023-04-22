using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RifleProjectile : MonoBehaviour
{
    private float timer = 0;
    //STATS FROM RIFLE
    private float projectileSpeed;
    private int projectileDamage;
    private float projectileLifeTime;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= projectileLifeTime)
            Destroy(gameObject);


        transform.position += transform.right * Time.deltaTime * projectileSpeed;
    }
    public void setProjectileStats(
        float pSpeed,
        int pDamage,
        float pLife
    )
    {
        projectileSpeed = pSpeed;
        projectileDamage = pDamage;
        projectileLifeTime = pLife;
    }
}
