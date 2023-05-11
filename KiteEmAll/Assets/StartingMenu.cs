using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingMenu : MonoBehaviour
{
    [SerializeField] WeaponData[] startingWeapons;
    [SerializeField] List<ActiveAbility> startingActiveAbilitys;
    [SerializeField] StartingWeaponSlot[] weaponSlots;
    [SerializeField] GameObject gameplayUI;

    private void Start()
    {
        Time.timeScale = 0;
        gameplayUI.SetActive(false);

        for (int i = 0; i < 5; i++)
        {
            weaponSlots[i].SetWeapon(startingWeapons[i]);
        }
    }


}
