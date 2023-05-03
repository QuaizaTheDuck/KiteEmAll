using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public bool interactPressed;
    [SerializeField] private float interactionRange = 5;
    [SerializeField] private LayerMask interactableLayerMask;

    public void setInteractPressed()
    {
        interactPressed = true;
    }
    private void Update()
    {
        if (interactPressed)
        {
            GameObject closestInteractable = GetClosestInteractable(interactionRange);

            if (closestInteractable != null)
            {
                // Interact with the closest interactable object
                closestInteractable.GetComponent<Interactable>().Interact();
            }
            interactPressed = false;
        }
    }

    private GameObject GetClosestInteractable(float range)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, range, interactableLayerMask);

        GameObject closestInteractable = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D hitCollider in hitColliders)
        {
            GameObject interactable = hitCollider.gameObject;
            float distance = Vector2.Distance(interactable.transform.position, transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestInteractable = interactable;
            }
        }

        return closestInteractable;
    }
}