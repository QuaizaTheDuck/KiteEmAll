using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ExpGem : MonoBehaviour
{
    private float rotationSpeed = 5f; // Initial rotation speed
    private bool isClockwise = true; // Start with clockwise rotation
    public float expGranted = 0;
    private Transform target;
    private bool isPickedUp = false;
    private void Update()
    {
        if (isPickedUp)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            transform.position += (Vector3)direction * 10 * Time.deltaTime;
        }

        // Rotate the object based on the current rotation direction and speed
        float rotationDirection = isClockwise ? 1f : -1f;
        transform.Rotate(Vector3.forward * rotationSpeed * rotationDirection * Time.deltaTime);
    }
    public void AutoDestro()
    {
        Destroy(gameObject);
    }
    public void Succ(Transform playerTrasform)
    {
        target = playerTrasform;
        isPickedUp = true;
    }
    private void Start()
    {
        transform.up = Random.insideUnitCircle.normalized;

        StartCoroutine(ChangeRotationDirectionAndSpeed());
    }
    public void setExpGranted(float exp)
    {
        expGranted = exp;
    }
    private IEnumerator ChangeRotationDirectionAndSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f); // Wait for 10 seconds

            // Toggle the rotation direction
            isClockwise = !isClockwise;

            // Change the rotation speed between 5 and 10
            rotationSpeed = isClockwise ? Random.Range(5f, 10f) : Random.Range(-10f, -5f);
        }
    }


}

