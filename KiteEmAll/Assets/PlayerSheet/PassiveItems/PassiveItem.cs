using UnityEngine;

[CreateAssetMenu]
public class PassiveItem : Item
{
    public float movementSpeedBonusFlat;
    public float movementSpeedBonusPercentAdd;
    public float movementSpeedBonusPercentMult;


    virtual public void Equip(PlayerStats player)
    {
        if (movementSpeedBonusFlat != 0)
            player.movementSpeed.AddModifier(new StatModifier(movementSpeedBonusFlat, StatModType.Flat, this));
        if (movementSpeedBonusPercentAdd != 0)
            player.movementSpeed.AddModifier(new StatModifier(movementSpeedBonusPercentAdd, StatModType.PercentAdd, this));
        if (movementSpeedBonusPercentAdd != 0)
            player.movementSpeed.AddModifier(new StatModifier(movementSpeedBonusPercentMult, StatModType.PercentMult, this));
    }

    virtual public void UnEquip(PlayerStats player)
    {
        player.movementSpeed.RemoveAllModifiersFromSource(this);
    }
}
