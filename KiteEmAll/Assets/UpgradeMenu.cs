using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject upgradeMenu;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] List<PassiveItem> upgradePool;
    [SerializeField] List<PassiveItem> upgradesToChooseFrom;
    [SerializeField] UpgradeButton[] upgradeButtons;


    private PassiveItem GetRandomUpgrade()
    {
        return upgradePool[Random.Range(0, upgradePool.Count)];
    }
    private void OnEnable()
    {
        Pause();

        Debug.Log("Losuje ulepszenia");
        for (int i = 0; i < 3; i++)
        {
            upgradeButtons[i].SetPassiveItem(GetRandomUpgrade());
        }

    }
    public void ToggleUpgradePanel()
    {
        if (!GameIsPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }
    public void Pause()
    {
        upgradeMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = !GameIsPaused;
    }

    public void Resume()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = !GameIsPaused;
    }
}
