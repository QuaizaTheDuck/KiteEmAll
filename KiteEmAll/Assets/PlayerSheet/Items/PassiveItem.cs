using UnityEngine;

[CreateAssetMenu]
public class PassiveItem : Item
{
    [SerializeField] private float maxHpBonusFlat;
    [SerializeField] private float maxHpPercentAdd;
    [SerializeField] private float maxHpPercentMult;
    [Space]
    [SerializeField] private float regenHpBonusFlat;
    [SerializeField] private float regenHpPercentAdd;
    [SerializeField] private float regenHpPercentMult;
    [Space]
    [SerializeField] private float movementSpeedBonusFlat;
    [SerializeField] private float movementSpeedBonusPercentAdd;
    [SerializeField] private float movementSpeedBonusPercentMult;
    [Space]
    [SerializeField] private float weaponAddedDamageBonusFlat;
    //[SerializeField] private float weaponAddedDamageBonusPercentAdd;
    //[SerializeField] private float weaponAddedDamageBonusPercentMult;
    [Space]
    //[SerializeField] private float weaponDamageMultiBonusFlat;
    [SerializeField] private float weaponDamageMultiBonusPercentAdd;
    [SerializeField] private float weaponDamageMultiBonusPercentMult;
    [Space]
    //[SerializeField] private float weaponActivationRateMultiBonusFlat;
    [SerializeField] private float weaponActivationRateMultiBonusPercentAdd;
    [SerializeField] private float weaponActivationRateMultiBonusPercentMult;
    [Space]
    [SerializeField] private float additionalProjectilesBonusFlat;
    [SerializeField] private float additionalProjectilesBonusPercentAdd;
    //  [SerializeField] private float additionalProjectilesBonusPercentMult;
    [Space]
    //[SerializeField] private float projectileSpreadMultiBonusFlat;
    [SerializeField] private float projectileSpreadMultiBonusPercentAdd;
    [SerializeField] private float projectileSpreadMultiBonusPercentMult;
    [Space]
    //[SerializeField] private float projectileSpeedMultiBonusFlat;
    [SerializeField] private float projectileSpeedMultiBonusPercentAdd;
    [SerializeField] private float projectileSpeedMultiBonusPercentMult;
    [Space]
    //[SerializeField] private float projectileTimeMultiBonusFlat;
    [SerializeField] private float projectileTimeMultiBonusPercentAdd;
    [SerializeField] private float projectileTimeMultiBonusPercentMult;
    [Space]
    [SerializeField] private float addedProjectilePierceBonusFlat;
    [SerializeField] private float addedProjectilePierceBonusPercentAdd;
    //[SerializeField] private float addedProjectilePierceBonusPercentMult;
    [Space]
    //[SerializeField] private float homingRangeMultiBonusFlat;
    [SerializeField] private float homingRangeMultiBonusPercentAdd;
    [SerializeField] private float homingRangeMultiBonusPercentMult;
    [Space]
    [SerializeField] private float homingAngleBonusFlat;
    [SerializeField] private float homingAngleBonusPercentAdd;
    [SerializeField] private float homingAngleBonusPercentMult;
    [Space]
    //[SerializeField] private float areaOfEffectMultiBonusFlat;
    [SerializeField] private float areaOfEffectMultiBonusPercentAdd;
    [SerializeField] private float areaOfEffectMultiBonusPercentMult;
    [Space]
    [SerializeField] private float gemPickUpRadiusBonusFlat;
    [SerializeField] private float gemPickUpRadiusBonusPercentAdd;
    [SerializeField] private float gemPickUpRadiusBonusPercentMult;

    virtual public void Equip(PlayerStats player)
    {

        if (maxHpBonusFlat != 0)
            player.maxHp.AddModifier(new StatModifier(maxHpBonusFlat, StatModType.Flat, this));
        if (maxHpPercentAdd != 0)
            player.maxHp.AddModifier(new StatModifier(maxHpPercentAdd, StatModType.PercentAdd, this));
        if (maxHpPercentMult != 0)
            player.maxHp.AddModifier(new StatModifier(maxHpPercentMult, StatModType.PercentMult, this));

        if (regenHpBonusFlat != 0)
            player.regenHp.AddModifier(new StatModifier(regenHpBonusFlat, StatModType.Flat, this));
        if (regenHpPercentAdd != 0)
            player.regenHp.AddModifier(new StatModifier(regenHpPercentAdd, StatModType.PercentAdd, this));
        if (regenHpPercentMult != 0)
            player.regenHp.AddModifier(new StatModifier(regenHpPercentMult, StatModType.PercentMult, this));

        if (movementSpeedBonusFlat != 0)
            player.movementSpeed.AddModifier(new StatModifier(movementSpeedBonusFlat, StatModType.Flat, this));
        if (movementSpeedBonusPercentAdd != 0)
            player.movementSpeed.AddModifier(new StatModifier(movementSpeedBonusPercentAdd, StatModType.PercentAdd, this));
        if (movementSpeedBonusPercentMult != 0)
            player.movementSpeed.AddModifier(new StatModifier(movementSpeedBonusPercentMult, StatModType.PercentMult, this));

        if (weaponAddedDamageBonusFlat != 0)
            player.weaponAddedDamage.AddModifier(new StatModifier(weaponAddedDamageBonusFlat, StatModType.Flat, this));
        /*        if (weaponAddedDamageBonusPercentAdd != 0)
                    player.weaponAddedDamage.AddModifier(new StatModifier(weaponAddedDamageBonusPercentAdd, StatModType.PercentAdd, this));
                if (weaponAddedDamageBonusPercentMult != 0)
                    player.weaponAddedDamage.AddModifier(new StatModifier(weaponAddedDamageBonusPercentMult, StatModType.PercentMult, this));
        */
        /*       if (weaponDamageMultiBonusFlat != 0)
                   player.weaponDamageMulti.AddModifier(new StatModifier(weaponDamageMultiBonusFlat, StatModType.Flat, this));
       */
        if (weaponDamageMultiBonusPercentAdd != 0)
            player.weaponDamageMulti.AddModifier(new StatModifier(weaponDamageMultiBonusPercentAdd, StatModType.PercentAdd, this));
        if (weaponDamageMultiBonusPercentMult != 0)
            player.weaponDamageMulti.AddModifier(new StatModifier(weaponDamageMultiBonusPercentMult, StatModType.PercentMult, this));

        /*        if (weaponActivationRateMultiBonusFlat != 0)
                    player.weaponActivationRateMulti.AddModifier(new StatModifier(weaponActivationRateMultiBonusFlat, StatModType.Flat, this));
        */
        if (weaponActivationRateMultiBonusPercentAdd != 0)
            player.weaponActivationRateMulti.AddModifier(new StatModifier(weaponActivationRateMultiBonusPercentAdd, StatModType.PercentAdd, this));
        if (weaponActivationRateMultiBonusPercentMult != 0)
            player.weaponActivationRateMulti.AddModifier(new StatModifier(weaponActivationRateMultiBonusPercentMult, StatModType.PercentMult, this));

        if (additionalProjectilesBonusFlat != 0)
        {
            player.additionalProjectiles.AddModifier(new StatModifier(additionalProjectilesBonusFlat, StatModType.Flat, this));
            Debug.Log("XDXD");
        }
        if (additionalProjectilesBonusPercentAdd != 0)
            player.additionalProjectiles.AddModifier(new StatModifier(additionalProjectilesBonusPercentAdd, StatModType.PercentAdd, this));
        /*       if (additionalProjectilesBonusPercentMult != 0)
                   player.additionalProjectiles.AddModifier(new StatModifier(additionalProjectilesBonusPercentMult, StatModType.PercentMult, this));
       */
        /*        if (projectileSpreadMultiBonusFlat != 0)
                    player.projectileSpreadMulti.AddModifier(new StatModifier(projectileSpreadMultiBonusFlat, StatModType.Flat, this));
        */
        if (projectileSpreadMultiBonusPercentAdd != 0)
            player.projectileSpreadMulti.AddModifier(new StatModifier(projectileSpreadMultiBonusPercentAdd, StatModType.PercentAdd, this));
        if (projectileSpreadMultiBonusPercentMult != 0)
            player.projectileSpreadMulti.AddModifier(new StatModifier(projectileSpreadMultiBonusPercentMult, StatModType.PercentMult, this));

        /*        if (projectileSpeedMultiBonusFlat != 0)
                    player.projectileSpeedMulti.AddModifier(new StatModifier(projectileSpeedMultiBonusFlat, StatModType.Flat, this));
        */
        if (projectileSpeedMultiBonusPercentAdd != 0)
            player.projectileSpeedMulti.AddModifier(new StatModifier(projectileSpeedMultiBonusPercentAdd, StatModType.PercentAdd, this));
        if (projectileSpeedMultiBonusPercentMult != 0)
            player.projectileSpeedMulti.AddModifier(new StatModifier(projectileSpeedMultiBonusPercentMult, StatModType.PercentMult, this));

        /*        if (projectileTimeMultiBonusFlat != 0)
                    player.projectileTimeMulti.AddModifier(new StatModifier(projectileTimeMultiBonusFlat, StatModType.Flat, this));
        */
        if (projectileTimeMultiBonusPercentAdd != 0)
            player.projectileTimeMulti.AddModifier(new StatModifier(projectileTimeMultiBonusPercentAdd, StatModType.PercentAdd, this));
        if (projectileTimeMultiBonusPercentMult != 0)
            player.projectileTimeMulti.AddModifier(new StatModifier(projectileTimeMultiBonusPercentMult, StatModType.PercentMult, this));

        if (addedProjectilePierceBonusFlat != 0)
            player.addedProjectilePierce.AddModifier(new StatModifier(addedProjectilePierceBonusFlat, StatModType.Flat, this));
        if (addedProjectilePierceBonusPercentAdd != 0)
            player.addedProjectilePierce.AddModifier(new StatModifier(addedProjectilePierceBonusPercentAdd, StatModType.PercentAdd, this));
        /*       if (addedProjectilePierceBonusPercentMult != 0)
                   player.addedProjectilePierce.AddModifier(new StatModifier(addedProjectilePierceBonusPercentMult, StatModType.PercentMult, this));
       */
        /*        if (homingRangeMultiBonusFlat != 0)
                    player.homingRangeMulti.AddModifier(new StatModifier(homingRangeMultiBonusFlat, StatModType.Flat, this));
        */
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

        /*        if (areaOfEffectMultiBonusFlat != 0)
                    player.areaOfEffectMulti.AddModifier(new StatModifier(areaOfEffectMultiBonusFlat, StatModType.Flat, this));
        */
        if (areaOfEffectMultiBonusPercentAdd != 0)
            player.areaOfEffectMulti.AddModifier(new StatModifier(areaOfEffectMultiBonusPercentAdd, StatModType.PercentAdd, this));
        if (areaOfEffectMultiBonusPercentMult != 0)
            player.areaOfEffectMulti.AddModifier(new StatModifier(areaOfEffectMultiBonusPercentMult, StatModType.PercentMult, this));

        if (gemPickUpRadiusBonusFlat != 0)
            player.gemPickUpRadius.AddModifier(new StatModifier(gemPickUpRadiusBonusFlat, StatModType.Flat, this));
        if (gemPickUpRadiusBonusPercentAdd != 0)
            player.gemPickUpRadius.AddModifier(new StatModifier(gemPickUpRadiusBonusPercentAdd, StatModType.PercentAdd, this));
        if (gemPickUpRadiusBonusPercentMult != 0)
            player.gemPickUpRadius.AddModifier(new StatModifier(gemPickUpRadiusBonusPercentMult, StatModType.PercentMult, this));

    }

    virtual public void UnEquip(PlayerStats player)
    {
        player.movementSpeed.RemoveAllModifiersFromSource(this);
    }

    public override string ToString()
    {
        string description = itemName + "\n";

        if (maxHpBonusFlat != 0)
            description += maxHpBonusFlat.ToString() + " to maximum Life" + "\n";
        if (maxHpPercentAdd != 0)
            description += (maxHpPercentAdd * 100).ToString() + "% to Life" + "\n";
        if (maxHpPercentMult > 0)
            description += (maxHpPercentMult * 100).ToString() + "% more Life" + "\n";
        if (maxHpPercentMult < 0)
            description += (maxHpPercentMult * 100).ToString() + "% less Life" + "\n";

        if (regenHpBonusFlat != 0)
            description += regenHpBonusFlat.ToString() + "% additional Life Regeneration" + "\n";
        if (regenHpPercentAdd != 0)
            description += (regenHpPercentAdd * 100).ToString() + "% to Life Regeneration" + "\n";
        if (regenHpPercentMult > 0)
            description += (regenHpPercentMult * 100).ToString() + "% more Life Regeneration" + "\n";
        if (regenHpPercentMult < 0)
            description += (regenHpPercentMult * 100).ToString() + "% Less Life Regeneration" + "\n";


        if (movementSpeedBonusFlat != 0)
            description += movementSpeedBonusFlat.ToString() + " to Movement Speed" + "\n";
        if (movementSpeedBonusPercentAdd != 0)
            description += (movementSpeedBonusPercentAdd * 100).ToString() + "% to Movement Speed" + "\n";
        if (movementSpeedBonusPercentMult > 0)
            description += (movementSpeedBonusPercentMult * 100).ToString() + "% more Movement Speed" + "\n";
        if (movementSpeedBonusPercentMult < 0)
            description += (movementSpeedBonusPercentMult * 100).ToString() + "% less Movement Speed" + "\n";

        if (weaponAddedDamageBonusFlat != 0)
            description += weaponAddedDamageBonusFlat.ToString() + " to Weapon Added Damage" + "\n";
        if (weaponDamageMultiBonusPercentAdd != 0)
            description += (weaponDamageMultiBonusPercentAdd * 100).ToString() + "% to Weapon Damage" + "\n";
        if (weaponDamageMultiBonusPercentMult > 0)
            description += (weaponDamageMultiBonusPercentMult * 100).ToString() + "% more Weapon Damage" + "\n";
        if (weaponDamageMultiBonusPercentMult < 0)
            description += (weaponDamageMultiBonusPercentMult * 100).ToString() + "% less Weapon Damage" + "\n";

        if (weaponActivationRateMultiBonusPercentAdd != 0)
            description += (weaponActivationRateMultiBonusPercentAdd * 100).ToString() + "% to Attack speed" + "\n";
        if (weaponActivationRateMultiBonusPercentMult > 0)
            description += (weaponActivationRateMultiBonusPercentMult * 100).ToString() + "% more Attack speed" + "\n";
        if (weaponActivationRateMultiBonusPercentMult < 0)
            description += (weaponActivationRateMultiBonusPercentMult * 100).ToString() + "% less Attack speed" + "\n";

        if (additionalProjectilesBonusFlat != 0)
            description += additionalProjectilesBonusFlat.ToString() + " Additional Projectiles" + "\n";
        if (additionalProjectilesBonusPercentAdd > 0)
            description += (additionalProjectilesBonusPercentAdd * 100).ToString() + "% more Projectiles" + "\n";
        if (additionalProjectilesBonusPercentAdd < 0)
            description += (additionalProjectilesBonusPercentAdd * 100).ToString() + "% less Projectiles" + "\n";
        /*      if (additionalProjectilesBonusPercentMult != 0)
                  description += additionalProjectilesBonusPercentMult.ToString() + "% more Additional Projectiles" + "\n";
      */
        if (projectileSpreadMultiBonusPercentAdd != 0)
            description += (projectileSpreadMultiBonusPercentAdd * 100).ToString() + "% to Projectile Spread" + "\n";
        if (projectileSpreadMultiBonusPercentMult > 0)
            description += (projectileSpreadMultiBonusPercentMult * 100).ToString() + "% more Projectile Spread" + "\n";
        if (projectileSpreadMultiBonusPercentMult < 0)
            description += (projectileSpreadMultiBonusPercentMult * 100).ToString() + "% less Projectile Spread" + "\n";

        if (projectileSpeedMultiBonusPercentAdd != 0)
            description += (projectileSpeedMultiBonusPercentAdd * 100).ToString() + "% to Projectile Speed" + "\n";
        if (projectileSpeedMultiBonusPercentMult > 0)
            description += (projectileSpeedMultiBonusPercentMult * 100).ToString() + "% more Projectile Speed" + "\n";
        if (projectileSpeedMultiBonusPercentMult < 0)
            description += (projectileSpeedMultiBonusPercentMult * 100).ToString() + "% less Projectile Speed" + "\n";

        if (projectileTimeMultiBonusPercentAdd != 0)
            description += (projectileTimeMultiBonusPercentAdd * 100).ToString() + "% to Projectile Time" + "\n";
        if (projectileTimeMultiBonusPercentMult > 0)
            description += (projectileTimeMultiBonusPercentMult * 100).ToString() + "% more Projectile Time" + "\n";
        if (projectileTimeMultiBonusPercentMult > 0)
            description += (projectileTimeMultiBonusPercentMult * 100).ToString() + "% less Projectile Time" + "\n";

        if (addedProjectilePierceBonusFlat != 0)
            description += addedProjectilePierceBonusFlat.ToString() + " to Pierce" + "\n";
        if (addedProjectilePierceBonusPercentAdd > 0)
            description += (addedProjectilePierceBonusPercentAdd * 100).ToString() + "% more Projectile Pierce" + "\n";
        if (addedProjectilePierceBonusPercentAdd > 0)
            description += (addedProjectilePierceBonusPercentAdd * 100).ToString() + "% less Projectile Pierce" + "\n";
        /*       if (addedProjectilePierceBonusPercentMult != 0)
                   description += addedProjectilePierceBonusPercentMult.ToString() + "% more Added Projectile Pierce" + "\n";
       */
        if (homingRangeMultiBonusPercentAdd != 0)
            description += (homingRangeMultiBonusPercentAdd * 100).ToString() + "% to Homing Range" + "\n";
        if (homingRangeMultiBonusPercentMult > 0)
            description += (homingRangeMultiBonusPercentMult * 100).ToString() + "% more Homing Range" + "\n";
        if (homingRangeMultiBonusPercentMult < 0)
            description += (homingRangeMultiBonusPercentMult * 100).ToString() + "% less Homing Range" + "\n";

        if (homingAngleBonusFlat != 0)
            description += homingAngleBonusFlat.ToString() + "° to Homing Angle" + "\n";
        if (homingAngleBonusPercentAdd != 0)
            description += (homingAngleBonusPercentAdd * 100).ToString() + "% to Homing Angle" + "\n";
        if (homingAngleBonusPercentMult > 0)
            description += (homingAngleBonusPercentMult * 100).ToString() + "% more Homing Angle" + "\n";
        if (homingAngleBonusPercentMult < 0)
            description += (homingAngleBonusPercentMult * 100).ToString() + "% less Homing Angle" + "\n";

        if (areaOfEffectMultiBonusPercentAdd != 0)
            description += (areaOfEffectMultiBonusPercentAdd * 100).ToString() + "% to Area of Effect" + "\n";
        if (areaOfEffectMultiBonusPercentMult > 0)
            description += (areaOfEffectMultiBonusPercentMult * 100).ToString() + "% more Area of Effect" + "\n";
        if (areaOfEffectMultiBonusPercentMult < 0)
            description += (areaOfEffectMultiBonusPercentMult * 100).ToString() + "% less Area of Effect" + "\n";

        if (gemPickUpRadiusBonusFlat != 0)
            description += gemPickUpRadiusBonusFlat.ToString() + " to Gem Pickup Radius" + "\n";
        if (gemPickUpRadiusBonusPercentAdd != 0)
            description += (gemPickUpRadiusBonusPercentAdd * 100).ToString() + "% to Gem Pickup Radius" + "\n";
        if (gemPickUpRadiusBonusPercentMult > 0)
            description += (gemPickUpRadiusBonusPercentMult * 100).ToString() + "% more Gem Pickup Radius" + "\n";
        if (gemPickUpRadiusBonusPercentMult < 0)
            description += (gemPickUpRadiusBonusPercentMult * 100).ToString() + "% less Gem Pickup Radius" + "\n";

        return description;
    }


}
