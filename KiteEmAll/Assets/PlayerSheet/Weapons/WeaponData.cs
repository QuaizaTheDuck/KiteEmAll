using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    //Podstawowe dane broni
    public string Name;
    public Sprite Icon;
    public GameObject weaponBasePrefab;//Prefab fukcji broni
}

