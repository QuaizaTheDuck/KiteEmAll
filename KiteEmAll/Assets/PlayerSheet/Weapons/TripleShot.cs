using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : WeaponBase
{
    [SerializeField] private GameObject projectilePrefab;
    public override void Activate(int damage, int projectileCount, float projectileSpeed, float projectileTime, float projectileSpread, int projectilePierce)
    {
        for (int i = -1; i <= 1; i++)
        {
            float fireAngle = 10 * i;
            Quaternion fireDirection = transform.rotation * Quaternion.AngleAxis(fireAngle, Vector3.forward);
            Instantiate(projectilePrefab, gameObject.transform.position, fireDirection);
        }
    }
}
