using UnityEngine;

[CreateAssetMenu]
public class PassiveItem : Item
{

    [SerializeField] private float movementSpeedBonusFlat;
    [SerializeField] private float movementSpeedBonusPercentAdd;
    [SerializeField] private float movementSpeedBonusPercentMult;
    [Space]
    [SerializeField] private float weaponAddedDamageBonusFlat;
    [SerializeField] private float weaponAddedDamageBonusPercentAdd;
    [SerializeField] private float weaponAddedDamageBonusPercentMult;
    [Space]
    [SerializeField] private float weaponDamageMultiBonusFlat;
    [SerializeField] private float weaponDamageMultiBonusPercentAdd;
    [SerializeField] private float weaponDamageMultiBonusPercentMult;
    [Space]
    [SerializeField] private float weaponActivationRateMultiBonusFlat;
    [SerializeField] private float weaponActivationRateMultiBonusPercentAdd;
    [SerializeField] private float weaponActivationRateMultiBonusPercentMult;
    [Space]
    [SerializeField] private float additionalProjectilesBonusFlat;
    [SerializeField] private float additionalProjectilesBonusPercentAdd;
    [SerializeField] private float additionalProjectilesBonusPercentMult;
    [Space]
    [SerializeField] private float projectileSpreadMultiBonusFlat;
    [SerializeField] private float projectileSpreadMultiBonusPercentAdd;
    [SerializeField] private float projectileSpreadMultiBonusPercentMult;
    [Space]
    [SerializeField] private float projectileSpeedMultiBonusFlat;
    [SerializeField] private float projectileSpeedMultiBonusPercentAdd;
    [SerializeField] private float projectileSpeedMultiBonusPercentMult;
    [Space]
    [SerializeField] private float projectileTimeMultiBonusFlat;
    [SerializeField] private float projectileTimeMultiBonusPercentAdd;
    [SerializeField] private float projectileTimeMultiBonusPercentMult;
    [Space]
    [SerializeField] private float addedProjectilePierceBonusFlat;
    [SerializeField] private float addedProjectilePierceBonusPercentAdd;
    [SerializeField] private float addedProjectilePierceBonusPercentMult;
    [Space]
    [SerializeField] private float homingRangeMultiBonusFlat;
    [SerializeField] private float homingRangeMultiBonusPercentAdd;
    [SerializeField] private float homingRangeMultiBonusPercentMult;
    [Space]
    [SerializeField] private float homingAngleBonusFlat;
    [SerializeField] private float homingAngleBonusPercentAdd;
    [SerializeField] private float homingAngleBonusPercentMult;
    [Space]
    [SerializeField] private float areaOfEffectMultiBonusFlat;
    [SerializeField] private float areaOfEffectMultiBonusPercentAdd;
    [SerializeField] private float areaOfEffectMultiBonusPercentMult;

    virtual public void Equip(PlayerStats player)
    {
        if (movementSpeedBonusFlat != 0)
            player.movementSpeed.AddModifier(new StatModifier(movementSpeedBonusFlat, StatModType.Flat, this));
        if (movementSpeedBonusPercentAdd != 0)
            player.movementSpeed.AddModifier(new StatModifier(movementSpeedBonusPercentAdd, StatModType.PercentAdd, this));
        if (movementSpeedBonusPercentAdd != 0)
            player.movementSpeed.AddModifier(new StatModifier(movementSpeedBonusPercentMult, StatModType.PercentMult, this));

        if (weaponAddedDamageBonusFlat != 0)
            player.weaponAddedDamage.AddModifier(new StatModifier(weaponAddedDamageBonusFlat, StatModType.Flat, this));
        if (weaponAddedDamageBonusPercentAdd != 0)
            player.weaponAddedDamage.AddModifier(new StatModifier(weaponAddedDamageBonusPercentAdd, StatModType.PercentAdd, this));
        if (weaponAddedDamageBonusPercentMult != 0)
            player.weaponAddedDamage.AddModifier(new StatModifier(weaponAddedDamageBonusPercentMult, StatModType.PercentMult, this));

        if (weaponDamageMultiBonusFlat != 0)
            player.weaponDamageMulti.AddModifier(new StatModifier(weaponDamageMultiBonusFlat, StatModType.Flat, this));
        if (weaponDamageMultiBonusPercentAdd != 0)
            player.weaponDamageMulti.AddModifier(new StatModifier(weaponDamageMultiBonusPercentAdd, StatModType.PercentAdd, this));
        if (weaponDamageMultiBonusPercentMult != 0)
            player.weaponDamageMulti.AddModifier(new StatModifier(weaponDamageMultiBonusPercentMult, StatModType.PercentMult, this));

        if (weaponActivationRateMultiBonusFlat != 0)
            player.weaponActivationRateMulti.AddModifier(new StatModifier(weaponActivationRateMultiBonusFlat, StatModType.Flat, this));
        if (weaponActivationRateMultiBonusPercentAdd != 0)
            player.weaponActivationRateMulti.AddModifier(new StatModifier(weaponActivationRateMultiBonusPercentAdd, StatModType.PercentAdd, this));
        if (weaponActivationRateMultiBonusPercentMult != 0)
            player.weaponActivationRateMulti.AddModifier(new StatModifier(weaponActivationRateMultiBonusPercentMult, StatModType.PercentMult, this));

        if (additionalProjectilesBonusFlat != 0)
            player.additionalProjectiles.AddModifier(new StatModifier(additionalProjectilesBonusFlat, StatModType.Flat, this));
        if (additionalProjectilesBonusPercentAdd != 0)
            player.additionalProjectiles.AddModifier(new StatModifier(additionalProjectilesBonusPercentAdd, StatModType.PercentAdd, this));
        if (additionalProjectilesBonusPercentMult != 0)
            player.additionalProjectiles.AddModifier(new StatModifier(additionalProjectilesBonusPercentMult, StatModType.PercentMult, this));

        if (projectileSpreadMultiBonusFlat != 0)
            player.projectileSpreadMulti.AddModifier(new StatModifier(projectileSpreadMultiBonusFlat, StatModType.Flat, this));
        if (projectileSpreadMultiBonusPercentAdd != 0)
            player.projectileSpreadMulti.AddModifier(new StatModifier(projectileSpreadMultiBonusPercentAdd, StatModType.PercentAdd, this));
        if (projectileSpreadMultiBonusPercentMult != 0)
            player.projectileSpreadMulti.AddModifier(new StatModifier(projectileSpreadMultiBonusPercentMult, StatModType.PercentMult, this));

        if (projectileSpeedMultiBonusFlat != 0)
            player.projectileSpeedMulti.AddModifier(new StatModifier(projectileSpeedMultiBonusFlat, StatModType.Flat, this));
        if (projectileSpeedMultiBonusPercentAdd != 0)
            player.projectileSpeedMulti.AddModifier(new StatModifier(projectileSpeedMultiBonusPercentAdd, StatModType.PercentAdd, this));
        if (projectileSpeedMultiBonusPercentMult != 0)
            player.projectileSpeedMulti.AddModifier(new StatModifier(projectileSpeedMultiBonusPercentMult, StatModType.PercentMult, this));

        if (projectileTimeMultiBonusFlat != 0)
            player.projectileTimeMulti.AddModifier(new StatModifier(projectileTimeMultiBonusFlat, StatModType.Flat, this));
        if (projectileTimeMultiBonusPercentAdd != 0)
            player.projectileTimeMulti.AddModifier(new StatModifier(projectileTimeMultiBonusPercentAdd, StatModType.PercentAdd, this));
        if (projectileTimeMultiBonusPercentMult != 0)
            player.projectileTimeMulti.AddModifier(new StatModifier(projectileTimeMultiBonusPercentMult, StatModType.PercentMult, this));

        if (addedProjectilePierceBonusFlat != 0)
            player.addedProjectilePierce.AddModifier(new StatModifier(addedProjectilePierceBonusFlat, StatModType.Flat, this));
        if (addedProjectilePierceBonusPercentAdd != 0)
            player.addedProjectilePierce.AddModifier(new StatModifier(addedProjectilePierceBonusPercentAdd, StatModType.PercentAdd, this));
        if (addedProjectilePierceBonusPercentMult != 0)
            player.addedProjectilePierce.AddModifier(new StatModifier(addedProjectilePierceBonusPercentMult, StatModType.PercentMult, this));

        if (homingRangeMultiBonusFlat != 0)
            player.homingRangeMulti.AddModifier(new StatModifier(homingRangeMultiBonusFlat, StatModType.Flat, this));
        if (homingRangeMultiBonusPercentAdd != 0)
            player.homingRangeMulti.AddModifier(new StatModifier(homingRangeMultiBonusPercentAdd, StatModType.PercentAdd, this));
        if (homingRangeMultiBonusPercentMult != 0)
            player.homingRangeMulti.AddModifier(new StatModifier(homingRangeMultiBonusPercentMult, StatModType.PercentMult, this));

        if (homingAngleBonusFlat != 0)
            player.homingAngle.AddModifier(new StatModifier(homingAngleBonusFlat, StatModType.Flat, this));
        if (homingAngleBonusPercentAdd != 0)
            player.homingAngle.AddModifier(new StatModifier(homingAngleBonusPercentAdd, StatModType.PercentAdd, this));
        if (homingAngleBonusPercentMult != 0)
            player.homingAngle.AddModifier(new StatModifier(homingAngleBonusPercentMult, StatModType.PercentMult, this));

        if (areaOfEffectMultiBonusFlat != 0)
            player.areaOfEffectMulti.AddModifier(new StatModifier(areaOfEffectMultiBonusFlat, StatModType.Flat, this));
        if (areaOfEffectMultiBonusPercentAdd != 0)
            player.areaOfEffectMulti.AddModifier(new StatModifier(areaOfEffectMultiBonusPercentAdd, StatModType.PercentAdd, this));
        if (areaOfEffectMultiBonusPercentMult != 0)
            player.areaOfEffectMulti.AddModifier(new StatModifier(areaOfEffectMultiBonusPercentMult, StatModType.PercentMult, this));
    }

    virtual public void UnEquip(PlayerStats player)
    {
        player.movementSpeed.RemoveAllModifiersFromSource(this);
    }
}
