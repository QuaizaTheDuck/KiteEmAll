using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBulletBehavior : MonoBehaviour
{
    private int projectileDamage = 80;
    private float projectileSpeed = 15;
    private float projectileTime = 2;
    private int projectilePierce = 0;
    public void setDefaultProjectileStats(int projectileDamage, float projectileSpeed, float projectileTime, int projectilePierce)
    {
        this.projectileDamage = projectileDamage;
        this.projectileSpeed = projectileSpeed;
        this.projectileTime = projectileTime;
        this.projectilePierce = projectilePierce;
        Destroy(gameObject, projectileTime);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * projectileSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        DefaultEnemy enemy = hit.GetComponent<DefaultEnemy>();
        if (enemy != null)
        {
            enemy.takeDamage(projectileDamage);
        }
    }
}
