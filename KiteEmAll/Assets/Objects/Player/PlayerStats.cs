using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float movementSpeed = 5;
    public int maxHp = 100;
    public int currentHp = 100;
    [SerializeField] UI_HpBarStatus hpBar;
    private bool isDead = false;
    // Update is called once per frame
    public void PlayerTakeDamage(int damage)
    {
        if (isDead == true) { return; }
        currentHp -= damage;
        if (currentHp <= 0)
        {
            GetComponent<PlayerGameOver>().GameOver();
            isDead = true;
        }
        hpBar.SetState(currentHp, maxHp);
    }
}
