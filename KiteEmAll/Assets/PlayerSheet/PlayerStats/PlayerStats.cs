using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public CharacterStat movementSpeed = new CharacterStat(5);

    public void Equip(PassiveItem passiveItem)
    {
        passiveItem.Equip(this);
    }
}