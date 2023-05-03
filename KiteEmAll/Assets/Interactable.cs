using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool isInteractedWith = false;
    public void Interact()
    {
        isInteractedWith = true;
        // Define the interaction behavior for this object
        Debug.Log("Interacting with " + gameObject.name);
    }
    protected void DeInteract()
    {
        isInteractedWith = false;
    }
}