using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityShield : ActiveAbility
{
    private GameObject player = null;

    public override void Activate()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        playerStats.invincibility.AddModifier(new StatModifier(1, StatModType.Flat, this));
        player.transform.Find("PlayerCore/PlayerOuterRing").GetComponent<RGB_effect>().activateRGB(5);

    }
    public override void DeActivate()
    {
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        playerStats.invincibility.RemoveAllModifiersFromSource(this);
    }


}
