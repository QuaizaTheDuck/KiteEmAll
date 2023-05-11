using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingWeaponSlot : MonoBehaviour
{
    [SerializeField] private WeaponData weapon;
    [SerializeField] private Image icon;
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private GameObject nextScreen;

    public void SetWeapon(WeaponData weapon)
    {
        this.weapon = weapon;
        icon.sprite = weapon.Icon;

    }

    public void SelectStartingWeapon()
    {
        weaponManager.AddWeapon(weapon);
        transform.parent.gameObject.SetActive(false);
        nextScreen.SetActive(true);
    }
}
