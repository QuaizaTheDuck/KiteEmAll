using System.Collections.Generic;
using UnityEngine;

public class ActiveAbilityInventory : MonoBehaviour
{
    [SerializeField] List<ActiveAbility> activeAbilities;
    [SerializeField] Transform activeAbilitysParent;
    [SerializeField] ActiveAbilitySlot[] activeAbilitySlots;

    private void OnValidate()
    {
        if (activeAbilitysParent != null)
            activeAbilitySlots = activeAbilitysParent.GetComponentsInChildren<ActiveAbilitySlot>();
        RefreshUI();
    }
    private void RefreshUI()
    {
        int i = 0;
        //dla każdego itema jaki posiadamy przypisujemy itemSlot
        for (; i < activeAbilities.Count && i < activeAbilitySlots.Length; i++)
        {
            activeAbilitySlots[i].activeAbility = activeAbilities[i];
        }
        //dla każdego pozostałego pustego itemSlota ustawiamy jego item jako null
        for (; i < activeAbilitySlots.Length; i++)
        {
            activeAbilitySlots[i].activeAbility = null;
        }
    }
    public bool AddItem(ActiveAbility activeAbility)
    {
        if (IsFull())
            return false;
        activeAbilities.Add(activeAbility);
        RefreshUI();
        return true;
    }

    public bool RemoveItem(ActiveAbility activeAbility)
    {
        if (activeAbilities.Remove(activeAbility))
        {
            RefreshUI();
            return true;
        }
        return false;
    }

    public bool IsFull()
    {
        return activeAbilities.Count >= activeAbilitySlots.Length;
    }
}
