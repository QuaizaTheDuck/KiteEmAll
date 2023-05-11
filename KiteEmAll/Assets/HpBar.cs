using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpBar : MonoBehaviour
{
    public Image hpBar;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private PlayerStats playerStats;
    private void Update()
    {
        Color HpBarColor = Color.Lerp(Color.red, Color.green, playerStats.currentHp / playerStats.maxHp.Value);
        hpBar.color = HpBarColor;
        lerpSpeed = 0.02f;
        hpBar.fillAmount = Mathf.Lerp(hpBar.fillAmount, playerStats.currentHp / playerStats.maxHp.Value, lerpSpeed); //playerStats.currentHp / playerStats.maxHp.Value;
    }

}
