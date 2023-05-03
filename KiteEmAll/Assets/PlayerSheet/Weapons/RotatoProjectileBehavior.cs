using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatoProjectileBehavior : MonoBehaviour
{
    private GameObject targetGo;
    private Transform target; // The target object to orbit around
    private Vector3 orbitPosition;
    private float radius = 5f; // The radius of the orbit
    private float speed = 20f; // The speed of the orbit around the center object
    private float startAngle = 0f; // The starting angle of the orbit in degrees
    /*
        private void Update()
        {
            // Calculate the new position in the orbit based on the speed and radius
            float angle = (Time.time * speed + startAngle) * Mathf.Deg2Rad;
            float x = target.position.x + Mathf.Cos(angle) * radius;
            float y = target.position.y + Mathf.Sin(angle) * radius;
            float z = target.position.z;
            orbitPosition = new Vector3(x, y, z);

            // Set the position of the GameObject to the new position in the orbit
            transform.position = orbitPosition;
        }

        public void setStats(float radius, float speed, float startAngle)
        {
            this.radius = radius;
            this.speed = speed;
            this.startAngle = startAngle;

            targetGo = GameObject.FindGameObjectWithTag("Player");
            target = targetGo.transform;

            float angle = startAngle * Mathf.Deg2Rad;
            float x = target.position.x + Mathf.Cos(angle) * radius;
            float y = target.position.y + Mathf.Sin(angle) * radius;
            float z = target.position.z;
            orbitPosition = new Vector3(x, y, z);
        }*/
}

