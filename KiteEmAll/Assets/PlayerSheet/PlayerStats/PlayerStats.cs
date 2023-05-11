
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerStats : MonoBehaviour
{
    [SerializeField] public Transform playerTrasform;

    //Player Character stats,,
    public CharacterStat maxHp = new CharacterStat(100);
    public CharacterStat regenHp = new CharacterStat(2);
    public float currentHp;
    public CharacterStat movementSpeed = new CharacterStat(5);
    // DAMAGE = ((WEAPON BASE DMG + (weaponAddedDamage * ADDED DMG EFFECTIVNES)) * weaponDamageMulti)
    // DPS = DAMAGE * ( 1 / (ACTIVATION COOLDOWN * weaponActivationRateMulti))

    //WEAPON STATS
    //FLAT Flatka dodana do broni jako dmg bazowy broni
    public CharacterStat weaponAddedDamage = new CharacterStat(0);
    //MULTI Mnożnik DMG BRONI
    public CharacterStat weaponDamageMulti = new CharacterStat(1);
    //FLAT Jak szybko leci czas dla ACTIVATIONTIMER
    public CharacterStat weaponActivationRateMulti = new CharacterStat(1);

    //PROJECTILE STATS
    //FLAT Dodatkowe projectile wystrzeliwane przez gracza
    public CharacterStat additionalProjectiles = new CharacterStat(0);
    //MULTI Mnożnik bazewego spreadu
    public CharacterStat projectileSpreadMulti = new CharacterStat(1);
    //MULTI Mnożnik prędkości posisków
    public CharacterStat projectileSpeedMulti = new CharacterStat(1);
    //MULTI Mnożnik czasu posisków
    public CharacterStat projectileTimeMulti = new CharacterStat(1);
    //FLAT Ile celów może trafic 1 pocisk
    public CharacterStat addedProjectilePierce = new CharacterStat(0);
    //MULTI Homing range multi
    public CharacterStat homingRangeMulti = new CharacterStat(1);
    //FLAT Homing Angle
    public CharacterStat homingAngle = new CharacterStat(0);
    //MULTI Increased area of effect
    public CharacterStat areaOfEffectMulti = new CharacterStat(0);

    //ABILITIS
    public CharacterStat invincibility = new CharacterStat(0);


    //EXP GEMS
    public CharacterStat gemPickUpRadius = new CharacterStat(5);
    [SerializeField] LayerMask expGemLayer;
    //EXP MANAGMENT
    public int playerLevel = 1;
    [SerializeField] public float currentExp = 0;
    [SerializeField] public float expNeededToLevelUp = 100;
    //LEVEL UP
    [SerializeField] private GameObject upgradeMenu;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject gameplayUI;
    private int score = 0;
    private float time = 0;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI currentScore;
    [SerializeField] TextMeshProUGUI bestTime;
    [SerializeField] TextMeshProUGUI currentTime;
    private bool scoreIsAdded = false;

    private void Update()
    {

        time += Time.deltaTime;
        if (currentHp < 0)
            GameOver();
        //life regen
        if (currentHp < maxHp.Value)
            currentHp += ((maxHp.Value / 100) * regenHp.Value) * Time.deltaTime;


        if (currentExp >= expNeededToLevelUp)
        {
            LevelUp();

        }

        //Wsysanie i niszczenie GEMOW
        if (Time.frameCount % 15 == 0)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(playerTrasform.position, gemPickUpRadius.Value, expGemLayer);

            foreach (var collider in colliders)
            {
                ExpGem gem = collider.GetComponent<ExpGem>();
                if ((collider.GetComponent<Transform>().position - transform.position).magnitude < 1)
                {
                    currentExp += gem.expGranted;
                    gem.AutoDestro();
                }
                collider.GetComponent<ExpGem>().Succ(playerTrasform);
            }
        }
        UpdateScores();
    }
    private void GameOver()
    {
        if (!scoreIsAdded)
        {
            score += (int)currentExp;
            scoreIsAdded = true;
        }
        CheckHighScore();
        resumeButton.SetActive(false);
        gameplayUI.SetActive(false);
        pauseMenu.Pause();
    }
    private void LevelUp()
    {
        score += (int)currentExp;
        upgradeMenu.SetActive(true);
        playerLevel++;
        currentExp = 0;
        expNeededToLevelUp = (float)Math.Round((expNeededToLevelUp + 100) * 1.1f, 0);
    }
    public void UpdateScores()
    {
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
        currentScore.text = $"Score: {score}";
        UpdateTimeText(time);

    }
    private void UpdateTimeText(float timeInSeconds)
    {
        int minutes = (int)(timeInSeconds / 60f);
        int seconds = (int)(timeInSeconds % 60f);

        currentTime.text = $"Time: {minutes:00}:{seconds:00}";
        int bestTimeMinutes = (int)(PlayerPrefs.GetFloat("BestTime", 0) / 60f);
        int bestTimeSeconds = (int)(PlayerPrefs.GetFloat("BestTime", 0) % 60f);
        bestTime.text = $"Best Time: {bestTimeMinutes:00}:{bestTimeSeconds:00}";
    }
    public void CheckHighScore()
    {

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        if (time > PlayerPrefs.GetFloat("BestTime", 0))
        {
            PlayerPrefs.SetFloat("BestTime", time);
        }
    }

    private void Start()
    {
        currentHp = maxHp.Value;
    }
    public void TakeDamage(float amountOfTakenDamage)
    {
        if (invincibility.Value <= 0)
            currentHp -= amountOfTakenDamage;
    }
    public void Equip(PassiveItem passiveItem)
    {
        passiveItem.Equip(this);
    }

}