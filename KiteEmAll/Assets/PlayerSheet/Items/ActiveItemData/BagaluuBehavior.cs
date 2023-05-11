using System.Collections;
using UnityEngine;

public class BagaluuBehavior : ActivateItemBehavior
{
    public override void ActivateItem(Component sender, object data)
    {
        playerStats.movementSpeed.AddModifier(new StatModifier((float)data / 40, StatModType.Flat, this));

        StartCoroutine(RemoveModifiersWithDelay(playerStats.weaponActivationRateMulti.Value / 3));
    }

    IEnumerator RemoveModifiersWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        playerStats.movementSpeed.RemoveAllModifiersFromSource(this);
    }
}
