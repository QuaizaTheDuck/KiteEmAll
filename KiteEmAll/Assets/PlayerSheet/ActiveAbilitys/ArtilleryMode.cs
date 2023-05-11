using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtilleryMode : ActiveAbility
{
    private GameObject player = null;
    private PlayerStats playerStats;
    public override void Activate()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        playerStats = player.GetComponent<PlayerStats>();

        playerStats.weaponAddedDamage.AddModifier(new StatModifier(10, StatModType.Flat, this));
        playerStats.weaponDamageMulti.AddModifier(new StatModifier(0.2f, StatModType.PercentMult, this));
        playerStats.additionalProjectiles.AddModifier(new StatModifier(4f, StatModType.Flat, this));
        playerStats.projectileSpeedMulti.AddModifier(new StatModifier(0.2f, StatModType.PercentMult, this));
        playerStats.additionalProjectiles.AddModifier(new StatModifier(1, StatModType.Flat, this));

        playerStats.movementSpeed.AddModifier(new StatModifier(-0.5f, StatModType.PercentMult, this));

    }

    public override void DeActivate()
    {
        playerStats.weaponAddedDamage.RemoveAllModifiersFromSource(this);
        playerStats.weaponDamageMulti.RemoveAllModifiersFromSource(this);
        playerStats.additionalProjectiles.RemoveAllModifiersFromSource(this);
        playerStats.projectileSpeedMulti.RemoveAllModifiersFromSource(this);
        playerStats.additionalProjectiles.RemoveAllModifiersFromSource(this);


        playerStats.movementSpeed.RemoveAllModifiersFromSource(this);
    }
}
