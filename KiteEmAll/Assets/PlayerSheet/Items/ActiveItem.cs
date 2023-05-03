using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ActiveItem : PassiveItem
{
    [SerializeField] GameObject pfActiveAbility;

    public override void Equip(PlayerStats player)
    {
        //DodajeStatystiki jak normalny item
        base.Equip(player);

        GameObject itemActiveAbility = Instantiate(pfActiveAbility, player.playerTrasform);
        ActivateItemBehavior prefabBehavior = itemActiveAbility.GetComponent<ActivateItemBehavior>();
        prefabBehavior.SetStats(player);
    }
}
