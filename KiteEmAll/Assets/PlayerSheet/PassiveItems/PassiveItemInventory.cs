using System.Collections.Generic;
using UnityEngine;

public class PassiveItemInventory : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] List<PassiveItem> passiveItems;
    [SerializeField] Transform passiveItemsParent;
    [SerializeField] PassiveItemSlot[] passiveItemSlots;



    private void OnValidate()
    {
        if (passiveItemsParent != null)
            passiveItemSlots = passiveItemsParent.GetComponentsInChildren<PassiveItemSlot>();
        RefreshUI();
    }
    private void RefreshUI()
    {
        int i = 0;
        //dla każdego itema jaki posiadamy przypisujemy itemSlot
        for (; i < passiveItems.Count && i < passiveItemSlots.Length; i++)
        {
            passiveItemSlots[i].passiveItem = passiveItems[i];
        }
        //dla każdego pozostałego pustego itemSlota ustawiamy jego item jako null
        for (; i < passiveItemSlots.Length; i++)
        {
            passiveItemSlots[i].passiveItem = null;
        }
    }
    public bool AddItem(PassiveItem passiveItem)
    {
        if (IsFull())
            return false;
        passiveItems.Add(passiveItem);
        passiveItem.Equip(playerStats);//Zakłada Item na gracza
        RefreshUI();
        return true;
    }

    public bool RemoveItem(PassiveItem passiveItem)
    {
        if (passiveItems.Remove(passiveItem))
        {
            RefreshUI();
            return true;
        }
        return false;
    }

    public bool IsFull()
    {
        return passiveItems.Count >= passiveItemSlots.Length;
    }
}
