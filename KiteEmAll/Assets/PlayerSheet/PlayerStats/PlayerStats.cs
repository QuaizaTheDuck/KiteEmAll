using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Player Character stats
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
    public void Equip(PassiveItem passiveItem)
    {
        passiveItem.Equip(this);
    }
}