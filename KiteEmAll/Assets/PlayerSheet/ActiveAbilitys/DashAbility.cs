using UnityEngine;

public class DashAbility : ActiveAbility
{
    private GameObject player = null;
    public override void Activate()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (player == null)
        {
            Debug.Log("PlayerNotFound");
        }
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        if (playerStats.movementSpeed.Value < 20)
            playerStats.movementSpeed.AddModifier(new StatModifier(20, StatModType.Flat, this));
        else
            playerStats.movementSpeed.AddModifier(new StatModifier(playerStats.movementSpeed.Value, StatModType.Flat, this));
    }

    public override void DeActivate()
    {
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        playerStats.movementSpeed.RemoveAllModifiersFromSource(this);
    }
}
