using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadWave : ActiveAbility
{
    private GameObject player = null;
    private bool toggle = false;
    public override void Activate()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        if (toggle == false)
        {
            playerStats.projectileSpreadMulti.RemoveAllModifiersFromSource(this);
            playerStats.projectileSpreadMulti.AddModifier(new StatModifier(0.5f, StatModType.PercentMult, this));
            toggle = !toggle;
        }
        if (toggle == true)
        {
            playerStats.projectileSpreadMulti.RemoveAllModifiersFromSource(this);
            playerStats.projectileSpreadMulti.AddModifier(new StatModifier(-0.5f, StatModType.PercentMult, this));
            toggle = !toggle;
        }


    }

    public override void DeActivate()
    {

    }
}
