using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public Transform playerTrasform;

    //Player Character stats
    public CharacterStat maxHp = new CharacterStat(100);
    public float currentHp;
    public CharacterStat movementSpeed = new CharacterStat(5);
    // DAMAGE = ((WEAPON BASE DMG + (weaponAddedDamage * ADDED DMG EFFECTIVNES)) * weaponDamageMulti)
    // DPS = DAMAGE * ( 1 / (ACTIVATION COOLDOWN * weaponActivationRateMulti))

    //WEAPON STATS
    //FLAT Flatka dodana do broni jako dmg bazowy broni
    public CharacterStat weaponAddedDamage = new CharacterStat(0);
    //MULTI Mnożnik DMG BRONI
    public CharacterStat weaponDamageMulti = new CharacterStat(1);
    //FLAT Jak szybko leci czas dla ACTIVATIONTIMER
    public CharacterStat weaponActivationRateMulti = new CharacterStat(1);

    //PROJECTILE STATS
    //FLAT Dodatkowe projectile wystrzeliwane przez gracza
    public CharacterStat additionalProjectiles = new CharacterStat(0);
    //MULTI Mnożnik bazewego spreadu
    public CharacterStat projectileSpreadMulti = new CharacterStat(1);
    //MULTI Mnożnik prędkości posisków
    public CharacterStat projectileSpeedMulti = new CharacterStat(1);
    //MULTI Mnożnik czasu posisków
    public CharacterStat projectileTimeMulti = new CharacterStat(1);
    //FLAT Ile celów może trafic 1 pocisk
    public CharacterStat addedProjectilePierce = new CharacterStat(0);
    //MULTI Homing range multi
    public CharacterStat homingRangeMulti = new CharacterStat(1);
    //FLAT Homing Angle
    public CharacterStat homingAngle = new CharacterStat(0);
    //MULTI Increased area of effect
    public CharacterStat areaOfEffectMulti = new CharacterStat(0);
    //EXP MANAGMENT
    public int playerLevel = 1;
    [SerializeField] float currtentExp = 0;
    [SerializeField] float expNeededToLevelUp = 100;
    public CharacterStat gemPickUpRadius = new CharacterStat(5);
    [SerializeField] LayerMask expGemLayer;

    private void Update()
    {
        Debug.Log("kutas");

        if (currtentExp >= expNeededToLevelUp)
        {

            playerLevel++;
            currtentExp = 0;
            expNeededToLevelUp = CalculateExpNeededToLevelUp(playerLevel);
        }//rewrasfdasdfasd

        if (Time.frameCount % 10 == 0)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(playerTrasform.position, gemPickUpRadius.Value, expGemLayer);

            foreach (var collider in colliders)
            {
                ExpGem gem = collider.GetComponent<ExpGem>();
                if ((collider.GetComponent<Transform>().position - transform.position).magnitude < 1)
                {
                    currtentExp += gem.expGranted;
                    gem.AutoDestro();
                }
                collider.GetComponent<ExpGem>().Succ(playerTrasform);
            }
        }

    }
    private int CalculateExpNeededToLevelUp(int level)
    {
        int baseExp = 100;
        int expMultiplier = 2;
        int maxLevel = 25;
        int linearExp = 1000; // Amount of additional experience needed per level after level 25

        if (level > maxLevel)
        {
            return int.MaxValue;
        }

        // Calculate the total experience needed to reach the desired level
        int totalExpNeeded = 0;
        if (level <= maxLevel)
        {
            for (int i = 1; i <= level; i++)
            {
                totalExpNeeded += baseExp * (int)Math.Pow(expMultiplier, i - 1);
            }
        }
        else
        {
            // Calculate the total experience needed for levels above 25 with linear growth
            int expNeededUpToLevel25 = CalculateExpNeededToLevelUp(maxLevel);
            totalExpNeeded = expNeededUpToLevel25 + (level - maxLevel) * linearExp;
        }

        // Calculate the difference between the previous level's total experience and the current level's total experience needed
        int expNeeded = totalExpNeeded - ((level - 1) >= 1 ? CalculateExpNeededToLevelUp(level - 1) : 0);
        return expNeeded;
    }

    private void Start()
    {
        currentHp = maxHp.Value;
    }
    public void TakeDamage(float amountOfTakenDamage)
    {
        currentHp -= amountOfTakenDamage;
        Debug.Log("PLAYER TOOK" + amountOfTakenDamage);
    }
    public void Equip(PassiveItem passiveItem)
    {
        passiveItem.Equip(this);
    }
}