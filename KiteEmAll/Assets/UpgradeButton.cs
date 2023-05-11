using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeButton : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] private PassiveItem passiveItem;
    [SerializeField] private GameObject passiveItemIconHolder;
    [SerializeField] private GameObject passiveItemDescription;
    [SerializeField] private PassiveItemInventory passiveItemInventory;
    public void SetPassiveItem(PassiveItem passiveItem)
    {
        this.passiveItem = passiveItem;
        passiveItemIconHolder.GetComponent<Image>().sprite = passiveItem.icon;
        passiveItemDescription.GetComponent<TextMeshProUGUI>().text = passiveItem.ToString();
    }

    public void equipItem()
    {
        playerStats.Equip(passiveItem);
        passiveItemInventory.AddItem(passiveItem);
        transform.parent.gameObject.GetComponent<UpgradeMenu>().Resume();
    }
}
