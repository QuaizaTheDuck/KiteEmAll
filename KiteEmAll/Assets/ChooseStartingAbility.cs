using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseStartingAbility : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] ActiveAbility activeAbility;
    [SerializeField] ActiveAbilityInventory activeAbilityInventory;
    [SerializeField] GameObject chooseSecondAbilityScreen = null;
    [SerializeField] GameObject gameplayUI;
    // Start is called before the first frame update
    private void OnEnable()
    {
        icon.sprite = activeAbility.icon;
    }
    public void selectAbility()
    {
        activeAbilityInventory.AddItem(activeAbility);
        transform.parent.gameObject.SetActive(false);
        if (chooseSecondAbilityScreen != null)
            chooseSecondAbilityScreen.SetActive(true);
        else
        {
            transform.parent.parent.gameObject.SetActive(false);
            gameplayUI.SetActive(true);
            Time.timeScale = 1;
        }
    }
}
