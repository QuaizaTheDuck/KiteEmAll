using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    //Referencja do statystyk gracza
    [SerializeField] protected PlayerStats playerStats;
    [SerializeField] protected float baseWeaponDamage = 80;
    //Jaki procent FLAT obrażeń gracza zadaje broń
    [SerializeField] protected float addedDamageEffectiveness = 1;
    //Czas po którym sie aktywuje
    [SerializeField] protected float activationCooldown = 1;
    [SerializeField] protected int baseProjectileCount = 1;
    [SerializeField] protected float addedProjectileEffectiveness = 1;
    [SerializeField] protected float baseProjectileSpeed = 10;
    [SerializeField] protected float baseProjectileTime = 2;
    [SerializeField] protected float baseProjectileSpread = 10;
    [SerializeField] protected int baseProjectilePierce = 0;
    private float baseActivationRate;
    private float activationRate;
    private float activationTimer;
    private int finalDamage;
    private void Awake()
    {
        //Znajdz Obiekt Gracza wyciagnij z niego PlayerStats
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();


        baseActivationRate = 1 / activationCooldown;
        activationTimer = 1 / (baseActivationRate * playerStats.weaponActivationRateMulti.Value);
    }
    private void Update()
    {
        activationTimer -= 1 * Time.deltaTime;
        if (activationTimer < 0)
        {
            Activate(
                calculateDamage(baseWeaponDamage, playerStats.weaponAddedDamage.Value, addedDamageEffectiveness, playerStats.weaponDamageMulti.Value),
                calculateProjectileCount(baseProjectileCount, playerStats.additionalProjectiles.Value, addedProjectileEffectiveness),
                calculateProjectileSpeed(baseProjectileSpeed, playerStats.projectileSpeedMulti.Value),
                calculateProjectileTime(baseProjectileTime, playerStats.projectileTimeMulti.Value),
                calculateProjectileSpread(baseProjectileSpread, playerStats.projectileSpreadMulti.Value),
                calculatePierce(baseProjectilePierce, playerStats.addedProjectilePierce.Value)
                );
            activationTimer = 1 / (baseActivationRate * playerStats.weaponActivationRateMulti.Value);
            //Debug.Log(activationTimer);
        }
    }
    public abstract void Activate(int damage, int projectileCount, float projectileSpeed, float projectileTime, float projectileSpread, int projectilePierce);
    protected int calculateDamage(float baseWeaponDamage, float weaponAddedDamage, float addedDamageEffectiveness, float weaponDamageMulti)
    {
        return (int)((baseWeaponDamage + (weaponAddedDamage * weaponAddedDamage)) * weaponDamageMulti);
    }
    protected int calculateProjectileCount(int baseProjectileCount, float additionalProjectiles, float addedProjectileEffectiveness)
    {
        return (int)(baseProjectileCount + (additionalProjectiles * addedProjectileEffectiveness));
    }
    protected float calculateProjectileSpeed(float baseProjectileSpeed, float projectileSpeedMulti)
    {
        return baseProjectileSpeed * projectileSpeedMulti;
    }
    protected float calculateProjectileTime(float baseProjectileTime, float projectileTimeMulti)
    {
        return projectileTimeMulti * projectileTimeMulti;
    }
    protected float calculateProjectileSpread(float baseProjectileSpread, float projectileSpreadMulti)
    {
        return baseProjectileSpread * projectileSpreadMulti;
    }
    protected int calculatePierce(int baseProjectilePierce, float addedprojectilePierce)
    {
        return (int)(baseProjectileSpread + addedprojectilePierce);
    }
}
