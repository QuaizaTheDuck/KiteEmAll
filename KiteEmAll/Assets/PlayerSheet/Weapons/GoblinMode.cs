using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMode : ActiveAbility
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

        playerStats.gemPickUpRadius.AddModifier(new StatModifier(5, StatModType.Flat, this));
        playerStats.gemPickUpRadius.AddModifier(new StatModifier(1f, StatModType.PercentMult, this));


    }

    public override void DeActivate()
    {
        playerStats.gemPickUpRadius.RemoveAllModifiersFromSource(this);
    }
}
