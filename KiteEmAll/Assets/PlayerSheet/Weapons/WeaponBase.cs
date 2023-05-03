using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    //Referencja do statystyk gracza
    private PlayerStats playerStats;
    [SerializeField] private float baseWeaponDamage = 80;
    //Jaki procent FLAT obrażeń gracza zadaje broń
    [SerializeField] private float addedDamageEffectiveness = 1;
    //Czas po którym sie aktywuje
    [SerializeField] private float activationCooldown = 1;
    [SerializeField] private int baseProjectileCount = 1;
    [SerializeField] private float addedProjectileEffectiveness = 1;
    [SerializeField] private float baseProjectileSpeed = 10;
    [SerializeField] private float baseProjectileTime = 2;
    [SerializeField] private float baseProjectileSpread = 10;
    [SerializeField] private int baseProjectilePierce = 1;
    [SerializeField] private float baseAreaOfEffect = 1;
    private float baseHomingRange;//baza to baseProjectileSpeed / 2
    private float baseActivationRate;
    private float activationRate;
    private float activationTimer;
    private int finalDamage;
    public GameEvent onPlayerWepActivation;

    private void Awake()
    {
        baseHomingRange = baseProjectileSpeed / 2;
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
                calculatePierce(baseProjectilePierce, playerStats.addedProjectilePierce.Value),
                calculateHomingRange(baseHomingRange, playerStats.homingRangeMulti.Value),
                playerStats.homingAngle.Value,
                calcualteAreaOfEffect(baseAreaOfEffect, playerStats.areaOfEffectMulti.Value)
                );
            onPlayerWepActivation.Raise(this, (1 / addedDamageEffectiveness) * baseWeaponDamage);
            activationTimer = 1 / (baseActivationRate * playerStats.weaponActivationRateMulti.Value);
            //Debug.Log(activationTimer);
        }
    }
    public abstract void Activate(int damage, int projectileCount, float projectileSpeed, float projectileTime, float projectileSpread, int projectilePierce, float homingRange, float homingAngle, float areaOfEffect);
    private float calcualteAreaOfEffect(float baseAreaOfEffect, float areaOfEffectMulti)
    {
        return baseAreaOfEffect * areaOfEffectMulti;
    }
    private float calculateHomingRange(float baseHomingRange, float homingRangeMulti)
    {
        return baseHomingRange * homingRangeMulti;
    }
    private int calculateDamage(float baseWeaponDamage, float weaponAddedDamage, float addedDamageEffectiveness, float weaponDamageMulti)
    {
        return (int)((baseWeaponDamage + (weaponAddedDamage * weaponAddedDamage)) * weaponDamageMulti);
    }
    private int calculateProjectileCount(int baseProjectileCount, float additionalProjectiles, float addedProjectileEffectiveness)
    {
        return (int)(baseProjectileCount + (additionalProjectiles * addedProjectileEffectiveness));
    }
    private float calculateProjectileSpeed(float baseProjectileSpeed, float projectileSpeedMulti)
    {
        return baseProjectileSpeed * projectileSpeedMulti;
    }
    private float calculateProjectileTime(float baseProjectileTime, float projectileTimeMulti)
    {
        return baseProjectileTime * projectileTimeMulti;
    }
    private float calculateProjectileSpread(float baseProjectileSpread, float projectileSpreadMulti)
    {
        return baseProjectileSpread * projectileSpreadMulti;
    }
    private int calculatePierce(int baseProjectilePierce, float addedProjectilePierce)
    {
        return (int)(baseProjectilePierce + addedProjectilePierce);
    }
}
