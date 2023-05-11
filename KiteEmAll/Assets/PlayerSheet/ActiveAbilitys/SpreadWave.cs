using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSpread : ActiveAbility
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
            playerStats.projectileSpreadMulti.AddModifier(new StatModifier(0.7f, StatModType.PercentMult, this));
            toggle = !toggle;
        }
        else
        {
            playerStats.projectileSpreadMulti.RemoveAllModifiersFromSource(this);
            playerStats.projectileSpreadMulti.AddModifier(new StatModifier(-0.7f, StatModType.PercentMult, this));
            toggle = !toggle;
        }


    }

    public override void DeActivate()
    {

    }
}
