using UnityEngine;


public class ItemChest : MonoBehaviour
{
    [SerializeField] PassiveItem passiveItem;
    [SerializeField] PassiveItemInventory passiveItemInventory;
    [SerializeField] SpriteRenderer spriteRenderer;
    private bool isInRange = false;
    private bool isEmpty = false;

    public bool isPressed = false;
    private void Start()
    {
        spriteRenderer.sprite = passiveItem.Icon;
        spriteRenderer.enabled = false;
    }
    public void setPress()
    {
        Debug.Log("CHEST PRESSED ++++++++++++");
        isPressed = true;
    }
    private void Update()
    {
        //DO PRZEPISANIA - ON TRIGEER ENTER POJAWIA SIE BUTTON I W NIEGO KLIK
        if (isInRange && (Input.GetKeyDown(KeyCode.Space) || isPressed))
        {
            if (!isEmpty)
            {
                passiveItemInventory.AddItem(passiveItem);
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        isInRange = true;
        spriteRenderer.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isInRange = false;
    }
}
