using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExpBar : MonoBehaviour
{
    public Image hpBar;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private PlayerStats playerStats;
    private void Update()
    {
        lerpSpeed = 3f * Time.deltaTime;
        hpBar.fillAmount = Mathf.Lerp(hpBar.fillAmount, playerStats.currentExp / playerStats.expNeededToLevelUp, lerpSpeed); //playerStats.currentHp / playerStats.maxHp.Value;
    }

}
