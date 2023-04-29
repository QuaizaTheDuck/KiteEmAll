using UnityEngine;


public class WeaponChest : MonoBehaviour
{

    [SerializeField] WeaponManager weaponManager;
    [SerializeField] WeaponData weaponInsideChest;

    [SerializeField] SpriteRenderer spriteRenderer;
    private bool isInRange = false;
    private bool isEmpty = false;

    public bool isPressed = false;
    private void Start()
    {
        //spriteRenderer.sprite = weaponInsideChest;
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
                weaponManager.AddWeapon(weaponInsideChest);
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        isInRange = true;
        //spriteRenderer.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isInRange = false;
    }
}
