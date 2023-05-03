using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatoGun : WeaponBase
{
    //Pocisk jakim Strzela broń
    [SerializeField] private GameObject projectilePrefab;
    private float rotationSpeed;

    private GameObject[] instantiatedObjects; // Array to store the instantiated objects
    /*
        private void spawnProjectile(GameObject projectilePrefab, Quaternion fireDirection, int damage, float projectileSpeed, float projectileTime, int projectilePierce, float homingRange, float homingAngle, float areaOfEffect)
        {
            // ==== !!!!! JESLI ERROR TO SPRAWDZ CZY W spawnedProjectile.GetComponent< XXX > JEST WŁASCIWA WARTOŚĆ
            GameObject spawnedProjectile = Instantiate(projectilePrefab, gameObject.transform.position, fireDirection);
            spawnedProjectile.GetComponent<DefaultBulletBehavior>().setDefaultProjectileStats(damage, projectileSpeed, projectileTime, projectilePierce, homingRange, homingAngle);
        }*/

    public override void Activate(int damage, int projectileCount, float projectileSpeed, float projectileTime, float projectileSpread, int projectilePierce, float homingRange, float homingAngle, float areaOfEffect)
    {
        rotationSpeed = projectileSpeed;

        Debug.Log(transform.rotation);

        float angleStep = 360f / projectileCount;

        // Instantiate the objects in a circle
        for (int i = 0; i < projectileCount; i++)
        {
            // Calculate the angle in radians
            float angle = i * angleStep * Mathf.Deg2Rad;
            float diffAngle = angleStep * i;

            // Calculate the position of the object
            Vector3 position = gameObject.transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * projectileSpread;

            // Instantiate the object at the calculated position
            GameObject rotatoProj = Instantiate(projectilePrefab, position, Quaternion.identity);
            rotatoProj.transform.SetParent(gameObject.transform);
        }
    }


}
