using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponObjectsContainer;
    [SerializeField] WeaponData startingWeapon;/*
    [SerializeField] WeaponData startingWeapon2;
    [SerializeField] WeaponData startingWeapon3;
    [SerializeField] WeaponData startingWeapon4;
    [SerializeField] WeaponData startingWeapon5;*/

    private void Start()
    {
        //AddWeapon(startingWeapon);
        /*AddWeapon(startingWeapon2);
        AddWeapon(startingWeapon3);
        AddWeapon(startingWeapon4);
        AddWeapon(startingWeapon5);*/

    }
    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectsContainer);
        weaponGameObject.transform.SetParent(this.transform);
    }
}
