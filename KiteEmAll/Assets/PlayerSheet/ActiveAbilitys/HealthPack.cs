using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : ActiveAbility
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

        if (playerStats.currentHp < playerStats.maxHp.Value * 0.5f)
            playerStats.currentHp += playerStats.maxHp.Value * 0.2f;
        playerStats.regenHp.AddModifier(new StatModifier(1, StatModType.PercentMult, this));

    }

    public override void DeActivate()
    {
        playerStats.regenHp.RemoveAllModifiersFromSource(this);
    }
}
