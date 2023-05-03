using UnityEngine;


public class ItemChest : Interactable
{
    [SerializeField] PassiveItem passiveItem;
    [SerializeField] LayerMask playerLayer;
    private bool isOpened = false;
    private void Update()
    {
        if (isInteractedWith)
        {
            if (isOpened)
            {
                Collider2D[] playerColliders = Physics2D.OverlapCircleAll(transform.position, 50, playerLayer);

                foreach (Collider2D playerCollider in playerColliders)
                {
                    GameObject playerObject = playerCollider.gameObject;

                    PassiveItemInventory playerInventory = playerObject.GetComponent<PassiveItemInventory>();
                    if (playerInventory != null)
                    {
                        playerInventory.AddItem(passiveItem);
                    }
                }
                Destroy(gameObject);
            }
            if (!isOpened)
            {
                DeInteract();
                isOpened = true;
            }
        }
    }
}
