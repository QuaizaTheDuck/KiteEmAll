using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProjectileBehavior : MonoBehaviour
{
    private int projectileDamage;
    private float projectileSpeed;
    private float projectileTime;
    private int projectilePierce;
    //Homing
    private float homingRange;
    private float homingAngle;
    float areaOfEffectMulti;
    private float lifeTimer = 0;
    //Layer w którym proj szuka celu
    [SerializeField] private float baseAreaOfEffect = 4;
    [SerializeField] private LayerMask homingTargetLayer;
    [SerializeField] private ParticleSystem particleSystemPrefab;
    private Transform currentTarget;

    private Rigidbody2D rb;

    public void setDefaultProjectileStats(
        int projectileDamage,
        float projectileSpeed,
        float projectileTime,
        int projectilePierce,
        float homingRange,
        float homingAngle,
        float areaOfEffectMulti)
    {
        this.projectileDamage = projectileDamage;
        this.projectileSpeed = projectileSpeed;
        this.projectileTime = projectileTime;
        this.projectilePierce = projectilePierce;
        this.homingRange = homingRange;
        this.homingAngle = homingAngle;
        this.areaOfEffectMulti = areaOfEffectMulti;

        //Nadaj predkosc
        Vector2 impulse = transform.up * projectileSpeed;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(impulse, ForceMode2D.Impulse);
    }
    void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= projectileTime)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D hit)
    {

        EnemyBase enemy = hit.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            enemy.TakeDamage(projectileDamage);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        ParticleSystem particleSystemInstance = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);
        var mainModule = particleSystemInstance.main;
        mainModule.startSpeed = new ParticleSystem.MinMaxCurve(baseAreaOfEffect / 2 * areaOfEffectMulti, baseAreaOfEffect * areaOfEffectMulti * 2);
        particleSystemInstance.Play();

        float totalDuration = particleSystemInstance.main.startLifetime.constant;
        Destroy(particleSystemInstance.gameObject, totalDuration);

        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, baseAreaOfEffect * areaOfEffectMulti, homingTargetLayer);
        //znajdz najblizszy target
        foreach (Collider2D target in targets)
        {

            EnemyBase enemy = target.GetComponent<EnemyBase>();
            if (enemy != null)
            {
                enemy.TakeDamage(projectileDamage);
            }

        }

    }
}
