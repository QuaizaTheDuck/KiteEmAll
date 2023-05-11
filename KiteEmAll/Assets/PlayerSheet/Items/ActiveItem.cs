using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ActiveItem : PassiveItem
{
    [SerializeField] GameObject pfActiveAbility;
    [SerializeField] private string behaviorDescription;

    public override void Equip(PlayerStats player)
    {
        //DodajeStatystiki jak normalny item
        base.Equip(player);

        GameObject itemActiveAbility = Instantiate(pfActiveAbility, player.playerTrasform);
        ActivateItemBehavior prefabBehavior = itemActiveAbility.GetComponent<ActivateItemBehavior>();
        prefabBehavior.SetStats(player);
    }

    public override string ToString()
    {
        description = base.ToString();
        description += behaviorDescription;
        return description;
    }
}
