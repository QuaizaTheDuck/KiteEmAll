using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamoNapr : ActiveAbility
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

        playerStats.homingAngle.AddModifier(new StatModifier(45, StatModType.Flat, this));
        playerStats.homingAngle.AddModifier(new StatModifier(0.2f, StatModType.PercentMult, this));
        playerStats.homingRangeMulti.AddModifier(new StatModifier(1, StatModType.PercentMult, this));

    }

    public override void DeActivate()
    {
        playerStats.homingAngle.RemoveAllModifiersFromSource(this);
        playerStats.homingRangeMulti.RemoveAllModifiersFromSource(this);
    }
}
